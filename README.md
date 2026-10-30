# leetcode

All [my LeetCode](https://leetcode.com/mnaoumov/) tasks solved

## Name

![](https://badges.peiyuan.ch/leetcode/mnaoumov/name)

## Ranking

![](https://badges.peiyuan.ch/leetcode/mnaoumov/ranking)

## Accepted Rate

![](https://badges.peiyuan.ch/leetcode/mnaoumov/rate?difficulty=all) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/rate?difficulty=easy) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/rate?difficulty=medium) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/rate?difficulty=hard)

## Solved Problems

![](https://badges.peiyuan.ch/leetcode/mnaoumov/solved?difficulty=all) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/solved?difficulty=easy) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/solved?difficulty=medium) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/solved?difficulty=hard)

## Submissions

![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=true&difficulty=all) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=true&difficulty=easy) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=true&difficulty=medium) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=true&difficulty=hard)

![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=false&difficulty=all) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=false&difficulty=easy) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=false&difficulty=medium) ![](https://badges.peiyuan.ch/leetcode/mnaoumov/submission?accepted=false&difficulty=hard)

## Layout

| Path | What it holds |
| --- | --- |
| `src/LeetCode.Framework` | Shared test infrastructure: test bases for C#, SQL, Bash and JavaScript problems, class design, data structures, helpers, algorithm templates |
| `src/LeetCode.Problems` | The problems, one folder each: `ISolution.cs`, `Solution<n>.cs` per attempt, `TestCase<n>.json`, `Tests.cs` |
| `src/LeetCode.Problems/<nn>` | Solved problems, bucketed by the first two digits of their number: `00/0001 Two Sum`, `39/3963 ...` |
| `src/LeetCode.Problems/!WIP` | The working set, the problems being worked on now |
| `src/LeetCode.Problems/!Unnumbered` | Problems LeetCode gives no number |
| `src/LeetCode.Problems/testcase.schema.json` | The test case schema; a test case with `"kind": "classDesign"` is checked as a class design one |
| `tests/` | Tests of the framework and of the tools |
| `tools/` | `TemplateGenerator` (new problem folders), `LeetCodeExporter` (copies a solution in LeetCode's format), `TestCaseExporter` (rewrites test case files), `leetcode-scraper` (problem and contest notes for the vault), `bookmarklet` |

## Building

`LeetCode.slnx` has two configurations:

1. `WIP`, the default, compiles only `!WIP`, so builds and test runs stay fast.
2. `Full` compiles every problem: `dotnet build -c Full`, `dotnet test -c Full`.

The JavaScript problems run on Node.js, so `node` and `npm` must be on `PATH`: the first build runs `npm ci` in `src/LeetCode.Framework/JavaScript` to restore `node_modules`, which is not committed.

A problem moves into `!WIP` to be worked on and back into its bucket when it is done. Within a problem folder, `Solution<n>` and `TestCase<n>` are padded to the width of the largest number, so they sort in order.

## Filing an issue (for AI agents and humans)

Open issues through the [issue forms](https://github.com/mnaoumov/leetcode/issues/new/choose), not as blank issues.

Filing from the CLI or the API (`gh issue create --body`, or an AI agent filing for you) skips the form, and `gh issue create --template` cannot load an issue form. In that case, open the matching form in [`.github/ISSUE_TEMPLATE/`](https://github.com/mnaoumov/leetcode/tree/HEAD/.github/ISSUE_TEMPLATE), copy every field as a `### <label>` heading in the form's order, and fill in each one. Always state the version you used and your operating system.
