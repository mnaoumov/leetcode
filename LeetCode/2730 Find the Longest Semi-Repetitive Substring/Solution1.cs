using JetBrains.Annotations;

namespace LeetCode._2730_Find_the_Longest_Semi_Repetitive_Substring;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-106/submissions/detail/968103468/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSemiRepetitiveSubstring(string s)
    {
        var ans = 0;
        var i = 0;
        var pairIndex = -1;
        var j = 0;

        while (j < s.Length)
        {
            if (j > 0 && s[j] == s[j - 1])
            {
                if (pairIndex == -1)
                {
                    pairIndex = j;
                }
                else
                {
                    i = pairIndex;
                    pairIndex = j;
                }
            }

            j++;

            ans = Math.Max(ans, j - i);
        }

        return ans;
    }
}
