using JetBrains.Annotations;

namespace LeetCode._2472_Maximum_Number_of_Non_overlapping_Palindrome_Substrings;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-319/submissions/detail/842386864/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaxPalindromes(string s, int k)
    {
        var palindromeIndexPairs = new List<(int startIndex, int endIndex)>();

        for (var endIndex = k - 1; endIndex < s.Length; endIndex++)
        {
            for (var startIndex = 0; startIndex <= endIndex + 1 - k; startIndex++)
            {
                if (IsPalindrome(startIndex, endIndex))
                {
                    palindromeIndexPairs.Add((startIndex, endIndex));
                }
            }
        }

        var result = 0;

        var lastEndIndex = -1;

        while (true)
        {
            var pair = palindromeIndexPairs.FirstOrDefault(p => p.startIndex > lastEndIndex);

            if (pair == (0, 0))
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