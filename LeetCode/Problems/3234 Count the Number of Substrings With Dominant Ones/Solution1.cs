using JetBrains.Annotations;

namespace LeetCode.Problems._3234_Count_the_Number_of_Substrings_With_Dominant_Ones;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-408/submissions/detail/1335763771/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int NumberOfSubstrings(string s)
    {
        var n = s.Length;
        var prefixOneCounts = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixOneCounts[i + 1] = prefixOneCounts[i] + (s[i] == '1' ? 1 : 0);
        }

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n + 1; j++)
            {
                var length = j - i;
                var onesCount = prefixOneCounts[j] - prefixOneCounts[i];
                var zerosCount = length - onesCount;
                if (onesCount >= zerosCount * zerosCount)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
