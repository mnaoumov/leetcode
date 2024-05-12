using JetBrains.Annotations;

namespace LeetCode.Problems._0097_Interleaving_String;

/// <summary>
/// https://leetcode.com/submissions/detail/829646929/
/// </summary>
[UsedImplicitly]
public class Solution8 : ISolution
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

        for (var index1 = s1.Length; index1 >= 0; index1--)
        {
            for (var index2 = s2.Length; index2 >= 0; index2--)
            {
                if (index1 == s1.Length && index2 == s2.Length)
                {
                    dp[index2] = true;
                }
                else
                {
                    var match1 = index1 < s1.Length && s1[index1] == s3[index1 + index2] && dp[index2];
                    var match2 = index2 < s2.Length && s2[index2] == s3[index1 + index2] && dp[index2 + 1];
                    dp[index2] = match1 || match2;
                }
            }
        }

        return dp[0];
    }
}
