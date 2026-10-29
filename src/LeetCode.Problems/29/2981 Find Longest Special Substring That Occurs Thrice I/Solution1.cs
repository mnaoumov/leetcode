namespace LeetCode.Problems._2981_Find_Longest_Special_Substring_That_Occurs_Thrice_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-378/submissions/detail/1132640878/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumLength(string s)
    {
        var n = s.Length;

        var counts = new Dictionary<string, int>();
        var ans = -1;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1 + Math.Max(ans, 0); j <= n; j++)
            {
                var subStr = s[i..j];
                counts.TryAdd(subStr, 0);
                counts[subStr]++;

                if (counts[subStr] >= 3)
                {
                    ans = Math.Max(ans, j - i);
                }
            }
        }

        return ans;
    }
}
