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

A problem moves into `!WIP` to be worked on and back into its bucket when it is done. Within a problem folder, `Solution<n>` and `TestCase<n>` are padded to the width of the largest number, so they sort in order.
