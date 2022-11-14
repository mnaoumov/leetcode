using JetBrains.Annotations;

namespace LeetCode._6236_Maximum_Number_of_Non_overlapping_Palindrome_Substrings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842394133/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaxPalindromes(string s, int k)
    {
        var palindromeIndexPairs = new List<(int startIndex, int endIndex)>();

        for (var endIndex = k - 1; endIndex < s.Length; endIndex++)
        {
            for (var startIndex = endIndex - k + 1; startIndex >= 0; startIndex--)
            {
                if (!IsPalindrome(startIndex, endIndex))
                {
                    continue;
                }

                palindromeIndexPairs.Add((startIndex, endIndex));
                break;
            }
        }

        var result = 0;

        var lastEndIndex = -1;

        while (true)
        {
            var missing = (startIndex: -1, endIndex: -1);
            var lastEndIndex2 = lastEndIndex;
            var pair = palindromeIndexPairs.FirstOrDefault(p => p.startIndex > lastEndIndex2, missing);

            if (pair == missing)
            {
                break;
            }

            result++;
            lastEndIndex = pair.endIndex;
        }

        return result;

        bool IsPalindrome(int startIndex, int endIndex)
        {
            while (startIndex < endIndex)
            {
                if (s[startIndex] != s[endIndex])
                {
                    return false;
                }

                startIndex++;
                endIndex--;
            }

            return true;
        }
    }
}