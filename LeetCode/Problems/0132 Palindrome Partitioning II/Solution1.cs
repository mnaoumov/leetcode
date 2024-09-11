using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0132_Palindrome_Partitioning_II;

/// <summary>
/// https://leetcode.com/problems/palindrome-partitioning-ii/submissions/836939651/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinCut(string s)
    {
        var isPalindromeDict = new Dictionary<(int startIndex, int endIndex), bool>();

        return Get(0);

        int Get(int startIndex)
        {
            if (startIndex >= s.Length)
            {
                return -1;
            }

            for (var endIndex = s.Length - 1; endIndex >= startIndex; endIndex--)
            {
                if (!IsPalindrome(startIndex, endIndex))
                {
                    continue;
                }

                return 1 + Get(endIndex + 1);
            }

            return -1;
        }

        bool IsPalindrome(int startIndex, int endIndex)
        {
            var key = (startIndex, endIndex);

            if (startIndex >= endIndex)
            {
                return true;
            }

            if (isPalindromeDict.TryGetValue(key, out var palindrome))
            {
                return palindrome;
            }

            return isPalindromeDict[key] = s[startIndex] == s[endIndex] && IsPalindrome(startIndex + 1, endIndex - 1);
        }

    }
}
