using JetBrains.Annotations;

namespace LeetCode.Problems._2609_Find_the_Longest_Balanced_Substring_of_a_Binary_String;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926277700/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindTheLongestBalancedSubstring(string s)
    {
        var result = 0;

        var zerosCount = 0;
        var onesCount = 0;

        foreach (var digit in s)
        {
            if (digit == '0')
            {
                if (onesCount == 0)
                {
                    zerosCount++;
                }
                else
                {
                    onesCount = 0;
                    zerosCount = 1;
                }
            }
            else if (onesCount < zerosCount)
            {
                onesCount++;
                result = Math.Max(result, 2 * onesCount);
            }
        }

        return result;
    }
}
