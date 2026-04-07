namespace LeetCode.Problems._3863_Minimum_Operations_to_Sort_a_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-492/problems/minimum-operations-to-sort-a-string/submissions/1941377718/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinOperations(string s)
    {
        var sorted = string.Concat(s.OrderBy(c => c));

        if (s == sorted)
        {
            return 0;
        }

        if (s.Length == 2)
        {
            const int impossible = -1;
            return impossible;
        }

        if (s[0] == sorted[0] || s[^1] == sorted[^1])
        {
            return 1;
        }

        if (s[..^2].Contains(sorted[0], StringComparison.Ordinal) || s[1..].Contains(sorted[^1], StringComparison.Ordinal))
        {
            return 2;
        }

        return 3;
    }
}
