using JetBrains.Annotations;

namespace LeetCode.Problems._0392_Is_Subsequence;

/// <summary>
/// https://leetcode.com/problems/is-subsequence/submissions/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsSubsequence(string s, string t)
    {
        var sIndex = 0;
        var tIndex = 0;

        while (sIndex < s.Length && tIndex < t.Length)
        {
            if (s[sIndex] == t[tIndex])
            {
                sIndex++;
            }

            tIndex++;
        }

        return sIndex == s.Length;
    }
}
