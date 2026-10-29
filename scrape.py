"""LeetCode scraper that generates Obsidian markdown files for new problems and contests,
and promotes contest solutions from !TODO to their real LeetCode problem numbers."""

import json
import re
import shutil
import time
import urllib.error
import urllib.request
from datetime import datetime, timezone
from html.parser import HTMLParser
from pathlib import Path

PROBLEMS_DIR = Path(r"F:\Obsidian\Projects\LeetCode\Problems")
WEEKLY_DIR = Path(r"F:\Obsidian\Projects\LeetCode\Contests\Weekly Contest")
BIWEEKLY_DIR = Path(r"F:\Obsidian\Projects\LeetCode\Contests\Biweekly Contest")
COOKIE_FILE = Path(__file__).parent / "leetcode_cookie.txt"
DAILY_WEEKLY_CACHE_FILE = Path(__file__).parent / "daily_weekly_cache.json"
SLUG_CACHE_FILE = Path(__file__).parent / "slug_cache.json"

# Reserved key inside DAILY_WEEKLY_CACHE_FILE holding the ISO timestamp of the
# last successful daily/weekly sync. Never collides with month keys ("YYYY-MM").
LAST_SYNC_KEY = "_last_sync"
# First year LeetCode daily challenges existed; nothing to fetch before this.
DAILY_CHALLENGE_START_YEAR = 2021

CS_PROBLEMS_DIR = Path(r"F:\dev\leetcode\LeetCode\Problems")
CS_TODO_DIR = CS_PROBLEMS_DIR / "!TODO"
WEEKLY_CONTEST_PREFIX = 10
BIWEEKLY_CONTEST_PREFIX = 20

GRAPHQL_URL = "https://leetcode.com/graphql"

PROBLEMSET_QUERY = """
query {
  problemsetQuestionListV2(
    categorySlug: ""
    limit: %d
    skip: %d
    filters: { filterCombineType: ALL }
  ) {
    totalLength
    questions {
      questionFrontendId
      title
      titleSlug
      difficulty
      paidOnly
      topicTags { name slug }
    }
  }
}
"""

PROBLEM_DETAIL_QUERY = """
query {
  question(titleSlug: "%s") {
    questionFrontendId
    title
    titleSlug
    difficulty
    isPaidOnly
    content
    codeSnippets { lang langSlug code }
    topicTags { name slug }
    positionLevelTags { name slug }
    companyTagStats
    hints
    similarQuestionList {
      questionFrontendId
      title
      titleSlug
      difficulty
    }
  }
}
"""

ALL_CONTESTS_QUERY = """
query {
  allContests {
    title
    titleSlug
    startTime
  }
}
"""

CONTEST_QUESTIONS_QUERY = """
query {
  contestQuestionList(contestSlug: "%s") {
    credit
    title
    titleSlug
    questionId
  }
}
"""

DAILY_CHALLENGE_QUERY = """
query($year: Int!, $month: Int!) {
  dailyCodingChallengeV2(year: $year, month: $month) {
    challenges {
      date
      question {
        questionFrontendId
        titleSlug
      }
    }
    weeklyChallenges {
      date
      question {
        questionFrontendId
        titleSlug
      }
    }
  }
}
"""


_cached_cookie = None
_cookie_loaded = False


def load_json_cache(path):
    """Load a JSON cache file, returning empty dict if missing or corrupt."""
    if path.exists():
        try:
            return json.loads(path.read_text(encoding="utf-8"))
        except (json.JSONDecodeError, OSError):
            pass
    return {}


def save_json_cache(path, data):
    """Save data to a JSON cache file."""
    path.write_text(json.dumps(data, separators=(",", ":")), encoding="utf-8")


def _extract_cookie_from_browser():
    """Try to extract LEETCODE_SESSION cookie from browser automatically."""
    try:
        import browser_cookie3
    except ImportError:
        return None

    for browser_fn in [browser_cookie3.chrome, browser_cookie3.edge, browser_cookie3.firefox]:
        try:
            cj = browser_fn(domain_name=".leetcode.com")
            for c in cj:
                if c.name == "LEETCODE_SESSION" and c.value:
                    return c.value
        except Exception:
            continue
    return None


def load_session_cookie():
    """Load LeetCode session cookie, trying file, browser extraction, then interactive prompt."""
    global _cached_cookie, _cookie_loaded
    if _cookie_loaded:
        return _cached_cookie
    _cookie_loaded = True

    if COOKIE_FILE.exists():
        cookie = COOKIE_FILE.read_text(encoding="utf-8").strip()
        if cookie:
            _cached_cookie = cookie
            return cookie

    print("No saved session cookie. Trying to extract from browser...")
    cookie = _extract_cookie_from_browser()
    if cookie:
        COOKIE_FILE.write_text(cookie, encoding="utf-8")
        print("Cookie extracted from browser and saved!")
        _cached_cookie = cookie
        return cookie

    print("Could not extract cookie automatically.")
    print("To get your LEETCODE_SESSION cookie:")
    print("  1. Open https://leetcode.com in Chrome and log in")
    print("  2. Open DevTools (F12) > Application > Cookies > leetcode.com")
    print("  3. Copy the value of LEETCODE_SESSION")
    cookie = input("Paste your LEETCODE_SESSION cookie (or press Enter to skip): ").strip()
    if cookie:
        COOKIE_FILE.write_text(cookie, encoding="utf-8")
        print("Cookie saved!")
        _cached_cookie = cookie
        return cookie
    return None


def graphql_request(query):
    """Send a GraphQL request to LeetCode API."""
    data = json.dumps({"query": query}).encode("utf-8")
    headers = {
        "Content-Type": "application/json",
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
        "Referer": "https://leetcode.com",
    }
    cookie = load_session_cookie()
    if cookie:
        headers["Cookie"] = f"LEETCODE_SESSION={cookie}"
    req = urllib.request.Request(
        GRAPHQL_URL,
        data=data,
        headers=headers,
    )
    with urllib.request.urlopen(req) as resp:
        return json.loads(resp.read().decode("utf-8"))


class HtmlToMarkdownConverter(HTMLParser):
    """Convert LeetCode HTML problem content to Obsidian-compatible markdown."""

    def __init__(self):
        super().__init__()
        self.result = []
        self.tag_stack = []
        self.list_stack = []
        self.in_pre = False
        self.pre_content = []
        self.table_rows = []
        self.current_row = []
        self.in_table = False
        self.in_td = False
        self.td_content = []
        self.in_example_io = False

    def _append(self, text):
        """Append text to the correct output target based on context."""
        if self.in_pre:
            self.pre_content.append(text)
        elif self.in_td:
            self.td_content.append(text)
        else:
            self.result.append(text)

    def handle_starttag(self, tag, attrs):
        attrs_dict = dict(attrs)
        self.tag_stack.append(tag)

        if tag == "p":
            pass
        elif tag in ("strong", "b"):
            self._append("**")
        elif tag in ("em", "i"):
            self._append("*")
        elif tag == "code":
            if not self.in_pre:
                self._append("`")
        elif tag == "pre":
            self.in_pre = True
            self.pre_content = []
        elif tag == "ul":
            self.list_stack.append("ul")
        elif tag == "ol":
            self.list_stack.append(("ol", 0))
        elif tag == "li":
            indent = "    " * (len(self.list_stack) - 1)
            if self.list_stack and isinstance(self.list_stack[-1], tuple):
                _, count = self.list_stack[-1]
                count += 1
                self.list_stack[-1] = ("ol", count)
                self._append(f"{indent}{count}. ")
            else:
                self._append(f"{indent}- ")
        elif tag == "br":
            self._append("\n")
        elif tag == "sup":
            self._append("^")
        elif tag == "sub":
            self._append("_")
        elif tag == "img":
            src = attrs_dict.get("src", "")
            alt = attrs_dict.get("alt", "")
            self._append(f"![{alt}]({src})")
        elif tag == "a":
            self._append("[")
        elif tag == "table":
            self.in_table = True
            self.table_rows = []
        elif tag == "tr":
            self.current_row = []
        elif tag in ("td", "th"):
            self.in_td = True
            self.td_content = []
        elif tag == "span":
            if attrs_dict.get("class") == "example-io":
                self.in_example_io = True
                self._append("`")
        elif tag == "blockquote":
            self._append("> ")

    def handle_endtag(self, tag):
        if self.tag_stack and self.tag_stack[-1] == tag:
            self.tag_stack.pop()

        if tag == "p":
            self._append("\n\n")
        elif tag in ("strong", "b"):
            self._append("**")
        elif tag in ("em", "i"):
            self._append("*")
        elif tag == "code":
            if not self.in_pre:
                self._append("`")
        elif tag == "pre":
            self.in_pre = False
            content = "".join(self.pre_content)
            self.result.append(f"```\n{content}\n```\n\n")
        elif tag in ("ul", "ol"):
            if self.list_stack:
                self.list_stack.pop()
            self._append("\n")
        elif tag == "li":
            self._append("\n")
        elif tag == "span":
            if self.in_example_io:
                self.in_example_io = False
                self._append("`")
        elif tag == "a":
            self._append("]")
        elif tag in ("td", "th"):
            self.in_td = False
            self.current_row.append("".join(self.td_content).strip())
        elif tag == "tr":
            self.table_rows.append(self.current_row)
        elif tag == "table":
            self.in_table = False
            if self.table_rows:
                self._render_table()
        elif tag == "blockquote":
            self._append("\n\n")

    def handle_data(self, data):
        if self.in_table and not self.in_td and not self.in_pre:
            return
        if not self.in_pre and not data.strip() and "\n" in data:
            return
        self._append(data)

    def handle_entityref(self, name):
        entity_map = {
            "amp": "&", "lt": "<", "gt": ">",
            "quot": '"', "apos": "'", "nbsp": " ",
        }
        self._append(entity_map.get(name, f"&{name};"))

    def handle_charref(self, name):
        if name.startswith("x"):
            char = chr(int(name[1:], 16))
        else:
            char = chr(int(name))
        self._append(char)

    def _render_table(self):
        if not self.table_rows:
            return
        col_count = max(len(row) for row in self.table_rows)
        for row in self.table_rows:
            while len(row) < col_count:
                row.append("")

        col_widths = []
        for col_idx in range(col_count):
            max_width = max(len(row[col_idx]) for row in self.table_rows)
            col_widths.append(max(max_width, 3))

        lines = []
        for row_idx, row in enumerate(self.table_rows):
            cells = [cell.ljust(col_widths[i]) for i, cell in enumerate(row)]
            lines.append("|" + "|".join(cells) + "|")
            if row_idx == 0:
                sep = ["-" * col_widths[i] for i in range(col_count)]
                lines.append("|" + "|".join(sep) + "|")

        self.result.append("\n".join(lines) + "\n\n")

    def get_markdown(self):
        text = "".join(self.result)
        text = re.sub(r"[\xa0 ]+\n", "\n", text)
        text = re.sub(r"\n{3,}", "\n\n", text)
        return text.strip()


def html_to_markdown(html_content):
    """Convert HTML to markdown."""
    if not html_content:
        return ""
    converter = HtmlToMarkdownConverter()
    converter.feed(html_content)
    return converter.get_markdown()


def clean_hint(hint_html):
    """Clean a hint from HTML to plain text."""
    hint_html = re.sub(r"<code>(.*?)</code>", r"`\1`", hint_html)
    hint_html = re.sub(r"<sup>(.*?)</sup>", r"^\1", hint_html)
    hint_html = re.sub(r"<[^>]+>", "", hint_html)
    hint_html = hint_html.replace("&lt;", "<").replace("&gt;", ">")
    hint_html = hint_html.replace("&amp;", "&").replace("&#39;", "'")
    hint_html = hint_html.replace("&quot;", '"')
    return hint_html.strip()


def get_existing_problem_numbers():
    """Get set of problem numbers already in the vault."""
    numbers = set()
    for f in PROBLEMS_DIR.iterdir():
        if f.suffix == ".md":
            match = re.match(r"(\d+)", f.name)
            if match:
                numbers.add(int(match.group(1)))
    return numbers


def get_existing_contests(contest_dir):
    """Get set of contest numbers already in the vault."""
    numbers = set()
    for f in contest_dir.iterdir():
        if f.suffix == ".md":
            match = re.search(r"(\d+)", f.name)
            if match:
                numbers.add(int(match.group(1)))
    return numbers


def fetch_all_problems(skip, limit):
    """Fetch problems from the problemset API."""
    result = graphql_request(PROBLEMSET_QUERY % (limit, skip))
    data = result["data"]["problemsetQuestionListV2"]
    return data["totalLength"], data["questions"]


def fetch_problem_detail(title_slug):
    """Fetch detailed problem info."""
    result = graphql_request(PROBLEM_DETAIL_QUERY % title_slug)
    return result["data"]["question"]


SUBMISSIONS_QUERY = """
query {
  questionSubmissionList(questionSlug: "%s", offset: %d, limit: 20, status: 10) {
    hasNext
    submissions { timestamp }
  }
}
"""


def fetch_first_accepted_date(title_slug):
    """Fetch the date of the first accepted submission for a problem."""
    cookie = load_session_cookie()
    if not cookie:
        return None

    offset = 0
    last_timestamp = None
    while True:
        try:
            result = graphql_request(SUBMISSIONS_QUERY % (title_slug, offset))
        except urllib.error.HTTPError:
            break
        data = result["data"]["questionSubmissionList"]
        if data is None:
            break
        submissions = data["submissions"]
        if not submissions:
            break
        last_timestamp = int(submissions[-1]["timestamp"])
        if not data["hasNext"]:
            break
        offset += 20
        time.sleep(0.3)

    if last_timestamp is None:
        return None
    return datetime.fromtimestamp(last_timestamp).astimezone().strftime("%Y-%m-%d")


def fetch_all_contests():
    """Fetch all contest metadata."""
    result = graphql_request(ALL_CONTESTS_QUERY)
    return result["data"]["allContests"]


def fetch_contest_questions(contest_slug):
    """Fetch questions for a specific contest."""
    result = graphql_request(CONTEST_QUESTIONS_QUERY % contest_slug)
    return result["data"]["contestQuestionList"]


def fetch_my_contest_ranking(contest_slug):
    """Fetch the logged-in user's ranking and submissions for a contest."""
    cookie = load_session_cookie()
    if not cookie:
        return None
    url = f"https://leetcode.com/contest/api/myranking/{contest_slug}/"
    headers = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
        "Referer": "https://leetcode.com",
        "Cookie": f"LEETCODE_SESSION={cookie}",
    }
    req = urllib.request.Request(url, headers=headers)
    try:
        with urllib.request.urlopen(req) as resp:
            return json.loads(resp.read().decode("utf-8"))
    except urllib.error.HTTPError:
        return None


def fetch_contest_participants(contest_slug):
    """Fetch total participant count for a contest."""
    url = f"https://leetcode.com/contest/api/ranking/{contest_slug}/?pagination=1&region=global"
    cookie = load_session_cookie()
    headers = {
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
        "Referer": "https://leetcode.com",
    }
    if cookie:
        headers["Cookie"] = f"LEETCODE_SESSION={cookie}"
    req = urllib.request.Request(url, headers=headers)
    try:
        with urllib.request.urlopen(req) as resp:
            data = json.loads(resp.read().decode("utf-8"))
            return data.get("user_num")
    except urllib.error.HTTPError:
        return None


def format_problem_number(num):
    """Format problem number with zero-padding."""
    return str(num).zfill(4)


def format_timestamp():
    """Get current timestamp in ISO format with timezone offset."""
    now = datetime.now().astimezone()
    ts = now.strftime("%Y-%m-%dT%H:%M:%S%z")
    return ts[:-2] + ":" + ts[-2:]


def generate_problem_markdown(detail, solved_date=None):
    """Generate Obsidian markdown for a problem."""
    num = int(detail["questionFrontendId"])
    padded = format_problem_number(num)
    title = detail["title"]
    full_title = f"{padded} {title}"
    difficulty = detail["difficulty"].capitalize()
    is_paid = detail["isPaidOnly"]
    title_slug = detail["titleSlug"]
    timestamp = format_timestamp()

    lines = []
    lines.append("---")
    lines.append(f"created: {timestamp}")
    lines.append(f"updated: {timestamp}")
    lines.append(f"title: {full_title}")
    lines.append(f'difficulty: "[{difficulty}](<../Difficulty/{difficulty}.md>)"')
    lines.append(f"source: https://leetcode.com/problems/{title_slug}/")

    if solved_date:
        lines.append(f"solved: {solved_date}")

    if is_paid:
        lines.append("tagLinks:")
        lines.append('  - "[Premium](<../Tags/Premium.md>)"')

    lines.append("---")
    lines.append("")
    lines.append(f"# {full_title}")
    lines.append("")

    content = detail.get("content")
    if content:
        md_content = html_to_markdown(content)
        lines.append(md_content)
        lines.append("")
    else:
        lines.append("*Premium content not available.*")
        lines.append("")

    topics = detail.get("topicTags") or []
    position_tags = detail.get("positionLevelTags") or []
    lines.append("## Topics")
    lines.append("")
    for topic in topics:
        lines.append(f"- [{topic['name']}](<../Topics/{topic['name']}.md>)")
    for tag in position_tags:
        lines.append(f"- [{tag['name']}](<../Topics/{tag['name']}.md>)")
    lines.append("")

    lines.append("## Companies")
    lines.append("")
    company_stats_raw = detail.get("companyTagStats")
    if company_stats_raw:
        company_stats = json.loads(company_stats_raw) if isinstance(company_stats_raw, str) else company_stats_raw
        seen_companies = set()
        for _period, companies in sorted(company_stats.items()):
            for company in companies:
                name = company.get("name", "")
                if name and name not in seen_companies:
                    seen_companies.add(name)
                    lines.append(f"- [{name}](<../Companies/{name}.md>)")
    lines.append("")

    lines.append("## Hints")
    lines.append("")
    hints = detail.get("hints") or []
    for hint in hints:
        cleaned = clean_hint(hint)
        lines.append(f"- {cleaned}")
    lines.append("")

    similar = detail.get("similarQuestionList") or []
    lines.append("## Similar Questions")
    lines.append("")
    for sq in similar:
        sq_num = int(sq["questionFrontendId"])
        sq_padded = format_problem_number(sq_num)
        sq_title = sq["title"]
        lines.append(f"- [{sq_padded} {sq_title}](<./{sq_padded} {sq_title}.md>)")
    lines.append("")

    lines.append("## Code template")
    lines.append("")
    code_snippets = detail.get("codeSnippets") or []
    cs_snippet = None
    sql_snippet = None
    for snippet in code_snippets:
        if snippet["langSlug"] == "csharp":
            cs_snippet = snippet
        elif snippet["langSlug"] == "mssql":
            sql_snippet = snippet
        elif snippet["langSlug"] == "mysql" and not sql_snippet:
            sql_snippet = snippet

    if cs_snippet:
        lines.append("```csharp")
        lines.append(cs_snippet["code"])
        lines.append("```")
    elif sql_snippet:
        lines.append("```sql")
        lines.append(sql_snippet["code"])
        lines.append("```")
    elif code_snippets:
        first = code_snippets[0]
        lines.append(f"```{first['langSlug']}")
        lines.append(first["code"])
        lines.append("```")
    lines.append("")

    lines.append("## Solution")
    lines.append("")
    lines.append("[No Solution](<../Tags/No Solution.md>)")

    text = "\n".join(lines)
    text = re.sub(r"\n{3,}", "\n\n", text)
    return text


def format_finish_time(finish_timestamp, start_timestamp):
    """Format contest finish time as HH:MM:SS duration from contest start."""
    elapsed = finish_timestamp - start_timestamp
    hours = elapsed // 3600
    minutes = (elapsed % 3600) // 60
    seconds = elapsed % 60
    return f"{hours}:{minutes:02d}:{seconds:02d}"


def generate_contest_markdown(contest_title, contest_slug, contest_date, problems_info,
                              my_ranking=None, participants=None, contest_start_time=None):
    """Generate Obsidian markdown for a contest."""
    date_link = contest_date
    timestamp = format_timestamp()
    na = '"[NA](<../../../../Tags/NA.md>)"'

    my_rank = my_ranking.get("my_rank") if my_ranking else None
    my_submissions = my_ranking.get("my_submission", {}) if my_ranking else {}
    my_solved = set(my_ranking.get("my_solved", [])) if my_ranking else set()

    rank_str = str(my_rank["rank"]) if my_rank else na
    participants_str = str(participants) if participants else na
    score_str = str(my_rank["score"]) if my_rank else na

    if my_rank and contest_start_time:
        finish_time_str = format_finish_time(my_rank["finish_time"], contest_start_time)
    else:
        finish_time_str = na

    lines = []
    lines.append("---")
    lines.append(f"created: {timestamp}")
    lines.append(f"updated: {timestamp}")
    lines.append(f"title: {contest_title}")
    lines.append(f"source: https://leetcode.com/contest/{contest_slug}/")
    lines.append(f"Date: {date_link}")
    lines.append(f"Rank: {rank_str}")
    lines.append(f"Participants: {participants_str}")
    lines.append(f"Score: {score_str}")
    lines.append(f"Finish time: {finish_time_str}")
    lines.append("Problems:")

    for idx, prob in enumerate(problems_info, 1):
        padded = format_problem_number(prob["number"])
        title = prob["title"]
        credit = prob["credit"]
        question_id = prob.get("question_id")

        if question_id and question_id in my_solved:
            sub = my_submissions.get(str(question_id), {})
            penalty = sub.get("fail_count", 0) * 5
            if contest_start_time:
                solve_time = format_finish_time(sub["date"], contest_start_time)
                if penalty:
                    result = f"Solved ({solve_time} + {penalty} min penalty)"
                else:
                    result = f"Solved ({solve_time})"
            else:
                result = "Solved"
            result_str = f'"[{result}](<../Solved.md>)"'
        else:
            result_str = '"[Did not solve](<../Did not solve.md>)"'

        lines.append(f"  - Problem Index: {idx}")
        lines.append(f'    Problem: "[{padded} {title}](<../../Problems/{padded} {title}.md>)"')
        lines.append(f"    Credit: {credit}")
        lines.append(f"    My result: {result_str}")

    lines.append("---")
    lines.append("")
    lines.append(f"# {contest_title}")

    return "\n".join(lines)


def parse_contest_dir(dir_name):
    """Parse contest info from directory name like '1049901 Valid Elements in an Array'.

    Numbering scheme: {type_prefix:2}{contest_num:3}{question_idx:2}
      - type_prefix 10 = weekly contest
      - type_prefix 20 = biweekly contest

    Returns (contest_slug, question_index_0based, name) or None.
    """
    match = re.match(r"(\d{7})\s+(.+)", dir_name)
    if not match:
        return None
    full_num = int(match.group(1))
    name = match.group(2)
    type_prefix = full_num // 100000
    contest_num = (full_num // 100) % 1000
    question_idx = (full_num % 100) - 1  # 0-based

    if type_prefix == WEEKLY_CONTEST_PREFIX:
        contest_slug = f"weekly-contest-{contest_num}"
    elif type_prefix == BIWEEKLY_CONTEST_PREFIX:
        contest_slug = f"biweekly-contest-{contest_num}"
    else:
        return None

    return contest_slug, question_idx, name


def detect_unsolved(problem_dir):
    """Check if a problem directory contains unsolved solutions."""
    for f in problem_dir.glob("Solution*.cs"):
        content = f.read_text(encoding="utf-8")
        if "SkipSolution" in content:
            return True
        if "NotImplementedException" in content:
            return True
    return False


def mark_unsolved_solution(solution_path):
    """Add [SkipSolution(SkipSolutionReason.NotImplemented)] if not already marked."""
    content = solution_path.read_text(encoding="utf-8")
    if "SkipSolution" in content:
        return False
    content = content.replace(
        "[UsedImplicitly]\npublic class ",
        "[UsedImplicitly]\n[SkipSolution(SkipSolutionReason.NotImplemented)]\npublic class ",
    )
    solution_path.write_text(content, encoding="utf-8")
    return True


def mark_unsolved_tests(tests_path):
    """Add [Category("TODO")] to Tests class if not already present."""
    content = tests_path.read_text(encoding="utf-8")
    if '[Category("TODO")]' in content:
        return False
    content = content.replace(
        "[UsedImplicitly]\npublic class Tests",
        '[UsedImplicitly]\n[Category("TODO")]\npublic class Tests',
    )
    tests_path.write_text(content, encoding="utf-8")
    return True


def update_cs_namespaces(problem_dir, old_num, new_num):
    """Replace old number prefix with new one in all .cs file namespaces."""
    for f in problem_dir.glob("*.cs"):
        content = f.read_text(encoding="utf-8")
        updated = content.replace(f"_{old_num}_", f"_{new_num}_")
        if updated != content:
            f.write_text(updated, encoding="utf-8")


def promote_todo_problems():
    """Promote contest problems from !TODO to their real LeetCode problem numbers."""
    if not CS_TODO_DIR.exists():
        return

    todo_dirs = []
    for d in sorted(CS_TODO_DIR.iterdir()):
        if d.is_dir():
            parsed = parse_contest_dir(d.name)
            if parsed:
                todo_dirs.append((d, *parsed))

    if not todo_dirs:
        return

    # Group by contest slug to minimize API calls
    contests = {}
    for d, contest_slug, q_idx, name in todo_dirs:
        contests.setdefault(contest_slug, []).append((d, q_idx, name))

    print(f"\nPromoting {len(todo_dirs)} problems across {len(contests)} contests...")

    # Fetch real problem numbers per contest
    problem_map = {}  # dir_path -> (real_number, real_title)

    for contest_slug, problems in sorted(contests.items()):
        print(f"  Fetching questions for {contest_slug}...")
        time.sleep(0.5)

        try:
            questions = fetch_contest_questions(contest_slug)
        except (urllib.error.HTTPError, KeyError) as e:
            print(f"    ERROR: Failed to fetch contest questions: {e}")
            continue

        if not questions:
            print(f"    WARNING: No questions returned, skipping")
            continue

        for d, q_idx, name in problems:
            if q_idx >= len(questions):
                print(f"    WARNING: Q{q_idx + 1} out of range ({len(questions)} questions)")
                continue

            title_slug = questions[q_idx]["titleSlug"]
            time.sleep(0.3)

            try:
                detail = fetch_problem_detail(title_slug)
                real_num = int(detail["questionFrontendId"])
                real_title = detail["title"]
            except (urllib.error.HTTPError, KeyError) as e:
                print(f"    ERROR: Failed to fetch {title_slug}: {e}")
                continue

            problem_map[d] = (real_num, real_title)
            padded = str(real_num).zfill(4)
            print(f"    Q{q_idx + 1}: {d.name} -> {padded} {real_title}")

    if not problem_map:
        print("  No problems to promote")
        return

    promoted = 0
    for dir_path, (real_num, real_title) in sorted(problem_map.items(), key=lambda x: x[1][0]):
        old_num_str = re.match(r"(\d+)", dir_path.name).group(1)
        padded = str(real_num).zfill(4)
        new_dir_name = f"{padded} {real_title}"
        target_path = CS_PROBLEMS_DIR / new_dir_name

        if target_path.exists():
            print(f"  SKIP: {new_dir_name} already exists")
            continue

        unsolved = detect_unsolved(dir_path)

        # Mark unsolved
        if unsolved:
            for sol in dir_path.glob("Solution*.cs"):
                mark_unsolved_solution(sol)
            tests = dir_path / "Tests.cs"
            if tests.exists():
                mark_unsolved_tests(tests)

        # Update namespaces
        update_cs_namespaces(dir_path, old_num_str, padded)

        # Move directory
        shutil.move(str(dir_path), str(target_path))
        status = " [UNSOLVED]" if unsolved else ""
        print(f"  Promoted: {new_dir_name}{status}")
        promoted += 1

    print(f"  {promoted} problems promoted")


def main():
    print("Fetching existing problems...")
    existing = get_existing_problem_numbers()
    print(f"Found {len(existing)} existing problems")

    print("\nFetching problem list from LeetCode...")
    total, _ = fetch_all_problems(0, 1)
    print(f"Total problems on LeetCode: {total}")

    max_existing = max(existing) if existing else 0
    skip = max(max_existing - 5, 0)
    limit = total - skip + 10

    _, all_problems = fetch_all_problems(skip, limit)
    print(f"Fetched {len(all_problems)} problems from index {skip}")

    new_problems = [p for p in all_problems if int(p["questionFrontendId"]) not in existing]
    new_problems.sort(key=lambda p: int(p["questionFrontendId"]))
    print(f"\nNew problems to scrape: {len(new_problems)}")

    if not new_problems:
        print("No new problems found!")
    else:
        for p in new_problems:
            print(f"  {p['questionFrontendId']:>4} {p['title']}")

        # Build slug-to-frontendId mapping from all fetched problems and merge with cache
        slug_to_frontend_id = load_json_cache(SLUG_CACHE_FILE)
        for p in all_problems:
            slug_to_frontend_id[p["titleSlug"]] = int(p["questionFrontendId"])
        save_json_cache(SLUG_CACHE_FILE, slug_to_frontend_id)

        problems_created = 0
        for i, prob in enumerate(new_problems):
            num = int(prob["questionFrontendId"])
            padded = format_problem_number(num)
            title = prob["title"]
            filename = f"{padded} {title}.md"
            filepath = PROBLEMS_DIR / filename

            print(f"\n[{i + 1}/{len(new_problems)}] Fetching {padded} {title}...")
            time.sleep(0.5)

            detail = fetch_problem_detail(prob["titleSlug"])
            solved_date = fetch_first_accepted_date(prob["titleSlug"])
            md = generate_problem_markdown(detail, solved_date=solved_date)
            filepath.write_text(md + "\n", encoding="utf-8")
            problems_created += 1
            print(f"  Created: {filename}")

        print(f"\n{'=' * 60}")
        print(f"Created {problems_created} problem files")

    # --- Contests ---
    print("\nFetching contest data...")
    all_contests = fetch_all_contests()
    now_ts = datetime.now(tz=timezone.utc).timestamp()
    # Contest must have started at least 1.5 hours ago to have questions available
    # (biweekly contests are 1.5h, weekly are 1.5h)
    contest_cutoff = now_ts - 5400

    existing_weekly = get_existing_contests(WEEKLY_DIR)
    existing_biweekly = get_existing_contests(BIWEEKLY_DIR)

    new_contests = []
    for c in all_contests:
        if c["startTime"] >= contest_cutoff:
            continue
        match = re.search(r"(\d+)", c["titleSlug"])
        if not match:
            continue
        num = int(match.group(1))
        is_biweekly = "biweekly" in c["titleSlug"]
        if is_biweekly:
            if num not in existing_biweekly:
                new_contests.append(c)
        elif "weekly" in c["titleSlug"]:
            if num not in existing_weekly:
                new_contests.append(c)

    new_contests.sort(key=lambda c: c["startTime"])

    if not new_contests:
        print("No new contests to create")
    else:
        print(f"\nNew contests to create: {len(new_contests)}")
        for c in new_contests:
            print(f"  {c['title']}")

        # Need slug_to_frontend_id for mapping contest questions
        # Use cache if we didn't build it from fetched problems above
        if not new_problems:
            slug_to_frontend_id = load_json_cache(SLUG_CACHE_FILE)

        for contest in new_contests:
            print(f"\n  Fetching questions for {contest['title']}...")
            time.sleep(0.3)
            contest_questions = fetch_contest_questions(contest["titleSlug"])

            if not contest_questions:
                print(f"    WARNING: No questions found, skipping")
                continue

            problems_info = []
            for cq in contest_questions:
                frontend_id = slug_to_frontend_id.get(cq["titleSlug"])
                if frontend_id is None:
                    # Fetch the problem to get its frontend ID
                    detail = fetch_problem_detail(cq["titleSlug"])
                    if detail is None:
                        print(f"    WARNING: Could not fetch {cq['title']}, skipping contest")
                        break
                    frontend_id = int(detail["questionFrontendId"])
                    slug_to_frontend_id[cq["titleSlug"]] = frontend_id
                    save_json_cache(SLUG_CACHE_FILE, slug_to_frontend_id)

                problems_info.append({
                    "number": frontend_id,
                    "title": cq["title"],
                    "credit": cq["credit"],
                    "question_id": int(cq["questionId"]),
                })
            else:
                # Only continue if the for loop completed without break
                pass

            if len(problems_info) != len(contest_questions):
                print(f"    Skipping {contest['title']} (incomplete data)")
                continue

            contest_date = datetime.fromtimestamp(
                contest["startTime"], tz=timezone.utc
            ).strftime("%Y-%m-%d")

            print(f"  Fetching contest results...")
            my_ranking = fetch_my_contest_ranking(contest["titleSlug"])
            participants = fetch_contest_participants(contest["titleSlug"])

            md = generate_contest_markdown(
                contest["title"],
                contest["titleSlug"],
                contest_date,
                problems_info,
                my_ranking=my_ranking,
                participants=participants,
                contest_start_time=contest["startTime"],
            )

            if "biweekly" in contest["titleSlug"]:
                contest_dir = BIWEEKLY_DIR
            else:
                contest_dir = WEEKLY_DIR

            filename = f"{contest['title']}.md"
            filepath = contest_dir / filename
            filepath.write_text(md + "\n", encoding="utf-8")
            print(f"  Created: {filename}")
            for idx, cp in enumerate(problems_info, 1):
                padded = format_problem_number(cp["number"])
                print(f"    Q{idx}: {padded} {cp['title']} (Credit: {cp['credit']})")

    # --- Backfill contest results ---
    backfill_contest_results(all_contests)

    # --- Backfill daily/weekly premium/solved ---
    backfill_daily_weekly_solved()

    # --- Promote contest solutions from !TODO ---
    promote_todo_problems()

    print("\nDone!")


def backfill_contest_results(all_contests):
    """Review and fix results for all existing contest files using the API."""
    cookie = load_session_cookie()
    if not cookie:
        print("\nSkipping contest backfill (no session cookie)")
        return

    na_marker = '"[NA](<../../../../Tags/NA.md>)"'
    contest_files = []
    for contest_dir in [WEEKLY_DIR, BIWEEKLY_DIR]:
        for f in sorted(contest_dir.iterdir()):
            if f.suffix != ".md":
                continue
            content = f.read_text(encoding="utf-8")
            # Only re-check contests that still have NA in metadata fields (Rank/Score/Finish time).
            # "Did not solve" is a valid final state and should not trigger re-processing.
            if na_marker not in content:
                continue
            match = re.search(r"source: https://leetcode\.com/contest/([^/]+)/", content)
            if match:
                contest_files.append((f, match.group(1)))

    if not contest_files:
        print("\nNo contest files need backfill")
        return

    print(f"\nReviewing results for {len(contest_files)} contests...")

    contest_start_times = {}
    for c in all_contests:
        contest_start_times[c["titleSlug"]] = c["startTime"]

    updated = 0
    skipped = 0
    for filepath, contest_slug in contest_files:
        time.sleep(0.2)
        my_ranking = fetch_my_contest_ranking(contest_slug)

        if not my_ranking or not my_ranking.get("my_rank"):
            # Clear NA markers so we don't re-check this contest next time
            content = filepath.read_text(encoding="utf-8")
            content = re.sub(r'Rank: .+', 'Rank: "-"', content)
            content = re.sub(r'Participants: .+', 'Participants: "-"', content)
            content = re.sub(r'Score: .+', 'Score: "-"', content)
            content = re.sub(r'Finish time: .+', 'Finish time: "-"', content)
            filepath.write_text(content, encoding="utf-8")
            skipped += 1
            continue

        start_time = contest_start_times.get(contest_slug)
        if not start_time:
            skipped += 1
            continue

        participants = fetch_contest_participants(contest_slug)
        my_rank = my_ranking["my_rank"]
        my_submissions = my_ranking.get("my_submission", {})
        my_solved = set(my_ranking.get("my_solved", []))

        finish_time_str = format_finish_time(my_rank["finish_time"], start_time)

        contest_questions = fetch_contest_questions(contest_slug)
        if not contest_questions:
            skipped += 1
            continue

        # Build the expected "My result" for each problem index
        expected_results = {}
        for idx, cq in enumerate(contest_questions):
            qid = int(cq["questionId"])
            if qid in my_solved:
                sub = my_submissions.get(str(qid))
                if sub:
                    solve_time = format_finish_time(sub["date"], start_time)
                    penalty = sub.get("fail_count", 0) * 5
                    if penalty:
                        result = f"Solved ({solve_time} + {penalty} min penalty)"
                    else:
                        result = f"Solved ({solve_time})"
                    expected_results[idx + 1] = f'"[{result}](<../Solved.md>)"'
                else:
                    expected_results[idx + 1] = '"[Did not solve](<../Did not solve.md>)"'
            else:
                expected_results[idx + 1] = '"[Did not solve](<../Did not solve.md>)"'

        # Read current content and rebuild the frontmatter
        content = filepath.read_text(encoding="utf-8")
        original = content

        # Replace Rank line
        content = re.sub(r'Rank: .+', f'Rank: {my_rank["rank"]}', content)

        # Replace Participants line
        if participants:
            content = re.sub(r'Participants: .+', f'Participants: {participants}', content)

        # Replace Score line
        content = re.sub(r'Score: .+', f'Score: {my_rank["score"]}', content)

        # Replace Finish time line
        content = re.sub(r'Finish time: .+', f'Finish time: {finish_time_str}', content)

        # Replace per-problem My result lines
        for prob_idx, expected in expected_results.items():
            # Find Problem Index: N, then its My result line
            pattern = rf'(  - Problem Index: {prob_idx}\n    Problem: .+\n    Credit: \d+\n    My result: ).+'
            replacement = rf'\g<1>{expected}'
            content = re.sub(pattern, replacement, content)

        if content != original:
            filepath.write_text(content, encoding="utf-8")
            updated += 1
            print(f"  Updated: {filepath.name} (Rank: {my_rank['rank']})")

    print(f"\nBackfill complete: {updated} updated, {skipped} not participated")


def fetch_daily_and_weekly_challenges(year, month):
    """Fetch daily and weekly premium challenges for a given month."""
    data = json.dumps({
        "query": DAILY_CHALLENGE_QUERY,
        "variables": {"year": year, "month": month},
    }).encode("utf-8")
    headers = {
        "Content-Type": "application/json",
        "User-Agent": "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36",
        "Referer": "https://leetcode.com",
    }
    cookie = load_session_cookie()
    if cookie:
        headers["Cookie"] = f"LEETCODE_SESSION={cookie}"
    req = urllib.request.Request(GRAPHQL_URL, data=data, headers=headers)
    try:
        with urllib.request.urlopen(req) as resp:
            result = json.loads(resp.read().decode("utf-8"))
            v2 = result["data"]["dailyCodingChallengeV2"]
            return v2.get("challenges", []), v2.get("weeklyChallenges", [])
    except (urllib.error.HTTPError, KeyError, TypeError):
        return [], []


def date_to_week_label(date_str):
    """Convert a date like '2026-04-08' to '2026-04-W2' (week within month)."""
    dt = datetime.strptime(date_str, "%Y-%m-%d")
    week_num = (dt.day - 1) // 7 + 1
    return f"{dt.year}-{dt.month:02d}-W{week_num}"


def backfill_daily_weekly_solved():
    """Backfill daily problem tags, weekly premium tags, and solved dates."""
    cookie = load_session_cookie()
    if not cookie:
        print("\nSkipping daily/weekly/solved backfill (no session cookie)")
        return

    # Build lookup: problem number -> filepath
    problem_files = {}
    for f in PROBLEMS_DIR.iterdir():
        if f.suffix == ".md":
            match = re.match(r"(\d+)", f.name)
            if match:
                problem_files[int(match.group(1))] = f

    # Fetch daily/weekly challenges, resuming from the last sync timestamp.
    now = datetime.now()
    daily_map = {}   # problem_number -> set of dates
    weekly_map = {}  # problem_number -> set of week labels

    cache = load_json_cache(DAILY_WEEKLY_CACHE_FILE)

    # Determine the earliest month that must be re-fetched. A daily/weekly
    # challenge posted after the previous sync would otherwise be lost: once its
    # month "completes" it would be served from a stale cache forever (e.g. last
    # sync on May 30, then the May 31 daily arrives — caching May as done loses
    # it). So re-fetch every month from the last sync's month onward, since that
    # sync may have run before the month's final challenges were posted. Older
    # months never change and stay cached.
    last_sync_raw = cache.get(LAST_SYNC_KEY)
    if last_sync_raw:
        last_sync = datetime.fromisoformat(last_sync_raw)
        refetch_from = (last_sync.year, last_sync.month)
    else:
        # No recorded sync (first run, or a cache predating the timestamp):
        # re-fetch the previous and current months to recover any data lost at
        # the last month rollover, without refetching the full history.
        if now.month == 1:
            refetch_from = (now.year - 1, 12)
        else:
            refetch_from = (now.year, now.month - 1)

    fetched_months = 0

    print("\nFetching daily/weekly challenge history...")
    for year in range(DAILY_CHALLENGE_START_YEAR, now.year + 1):
        end_month = 12 if year < now.year else now.month
        for month in range(1, end_month + 1):
            month_key = f"{year}-{month:02d}"
            cached = cache.get(month_key)
            must_refetch = (year, month) >= refetch_from

            if cached is not None and not must_refetch:
                # Use cached data for settled months.
                daily = cached.get("daily", [])
                weekly = cached.get("weekly", [])
            else:
                # Fetch from API: months at/after the last sync, or uncached.
                time.sleep(0.3)
                daily, weekly = fetch_daily_and_weekly_challenges(year, month)
                cache[month_key] = {"daily": daily, "weekly": weekly}
                fetched_months += 1

            for entry in daily:
                num = int(entry["question"]["questionFrontendId"])
                date = entry["date"]
                daily_map.setdefault(num, set()).add(date)

            for entry in weekly:
                num = int(entry["question"]["questionFrontendId"])
                date = entry["date"]
                label = date_to_week_label(date)
                weekly_map.setdefault(num, set()).add(label)

    # Record this sync so the next run resumes from here.
    cache[LAST_SYNC_KEY] = now.isoformat()
    save_json_cache(DAILY_WEEKLY_CACHE_FILE, cache)
    print(f"  Fetched {fetched_months} months from API (rest from cache)")

    # Now update problem files
    updated = 0
    solved_added = 0

    for num, filepath in sorted(problem_files.items()):
        api_daily = daily_map.get(num, set())
        api_weekly = weekly_map.get(num, set())

        if not api_daily and not api_weekly:
            continue

        content = filepath.read_text(encoding="utf-8")
        original = content

        # Check if we need to update anything for this problem
        needs_solved = "solved:" not in content

        # Parse existing daily entries
        existing_daily = set()
        for m in re.finditer(r'dailyProblems:\n((?:  - .+\n)*)', content):
            for dm in re.finditer(r'(\d{4}-\d{2}-\d{2})', m.group(1)):
                existing_daily.add(dm.group(1))

        # Parse existing weekly entries
        existing_weekly = set()
        for m in re.finditer(r'weeklyPremiumProblems:\n((?:  - .+\n)*)', content):
            for wm in re.finditer(r'(\d{4}-\d{2}-W\d+)', m.group(1)):
                existing_weekly.add(wm.group(1))

        new_daily = sorted(api_daily - existing_daily)
        new_weekly = sorted(api_weekly - existing_weekly)

        if not new_daily and not new_weekly:
            continue

        # Find the end of frontmatter to insert before ---
        fm_match = re.match(r'(---\n)(.*?\n)(---\n)', content, re.DOTALL)
        if not fm_match:
            continue

        frontmatter = fm_match.group(2)
        after_fm = content[fm_match.end():]

        # Add new daily entries
        if new_daily:
            if "dailyProblems:" in frontmatter:
                # Find the dailyProblems block and append entries
                daily_entries = "\n".join(f"  - {d}" for d in new_daily)
                # Insert after existing dailyProblems entries
                frontmatter = re.sub(
                    r'(dailyProblems:\n(?:  - .+\n)*)',
                    lambda m: m.group(1) + daily_entries + "\n",
                    frontmatter,
                )
            else:
                # Add dailyProblems section before ---
                daily_entries = "dailyProblems:\n" + "\n".join(
                    f"  - {d}" for d in sorted(api_daily)
                ) + "\n"
                frontmatter += daily_entries

        # Add new weekly entries
        if new_weekly:
            if "weeklyPremiumProblems:" in frontmatter:
                weekly_entries = "\n".join(f"  - {w}" for w in new_weekly)
                frontmatter = re.sub(
                    r'(weeklyPremiumProblems:\n(?:  - .+\n)*)',
                    lambda m: m.group(1) + weekly_entries + "\n",
                    frontmatter,
                )
            else:
                weekly_entries = "weeklyPremiumProblems:\n" + "\n".join(
                    f"  - {w}" for w in sorted(api_weekly)
                ) + "\n"
                frontmatter += weekly_entries

        # Add solved date if missing — only check for problems that got new daily/weekly entries
        if needs_solved and (new_daily or new_weekly):
            slug_match = re.search(r"source: https://leetcode\.com/problems/([^/]+)/", frontmatter)
            if slug_match:
                title_slug = slug_match.group(1)
                print(f"  Checking solved: {filepath.name}...", end="\r")
                try:
                    solved_date = fetch_first_accepted_date(title_slug)
                except Exception:
                    solved_date = None
                if solved_date:
                    frontmatter = re.sub(
                        r'(source: .+\n)',
                        rf'\g<1>solved: {solved_date}\n',
                        frontmatter,
                    )
                    solved_added += 1
                time.sleep(0.5)

        content = "---\n" + frontmatter + "---\n" + after_fm

        if content != original:
            filepath.write_text(content, encoding="utf-8")
            updated += 1
            changes = []
            if new_daily:
                changes.append(f"{len(new_daily)} daily")
            if new_weekly:
                changes.append(f"{len(new_weekly)} weekly")
            if needs_solved and "solved:" in content and "solved:" not in original:
                changes.append("solved")
            print(f"  Updated: {filepath.name} ({', '.join(changes)})")

    print(f"\nDaily/weekly/solved backfill: {updated} files updated, {solved_added} solved dates added")


if __name__ == "__main__":
    main()
