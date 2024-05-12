using JetBrains.Annotations;

namespace LeetCode._0132_Palindrome_Partitioning_II;

/// <summary>
/// https://leetcode.com/problems/palindrome-partitioning-ii/submissions/836942040/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinCut(string s)
    {
        var isPalindromeDict = new Dictionary<(int startIndex, int endIndex), bool>();
        var cache = new Dictionary<int, int>();

        return Get(0);

        int Get(int startIndex)
        {
            if (startIndex >= s.Length)
            {
                return -1;
            }

            if (cache.TryGetValue(startIndex, out var value))
            {
                return value;
            }

            var subResults = new List<int>();

            for (var endIndex = s.Length - 1; endIndex >= startIndex; endIndex--)
            {
                if (!IsPalindrome(startIndex, endIndex))
                {
                    continue;
                }

                subResults.Add(1 + Get(endIndex + 1));
            }

            return cache[startIndex] = subResults.Min();
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
