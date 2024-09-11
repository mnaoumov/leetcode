using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0097_Interleaving_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829638365/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
{
    public bool IsInterleave(string s1, string s2, string s3)
    {
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        if (s1.Length == 0)
        {
            return s2 == s3;
        }

        if (s2.Length == 0)
        {
            return s1 == s3;
        }

        var dp = new bool[s2.Length + 1];
        dp[s2.Length] = true;

        for (var index1 = s1.Length - 1; index1 >= 0; index1--)
        {
            for (var index2 = s2.Length - 1; index2 >= 0; index2--)
            {
                var match1 = s1[index1] == s3[index1 + index2] && dp[index2];
                var match2 = s2[index2] == s3[index1 + index2] && dp[index2 + 1];
                dp[index2] = match1 || match2;
            }

            dp[s2.Length] = false;
        }

        return dp[0];
    }
}
