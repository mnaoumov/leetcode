namespace LeetCode.Problems._2472_Maximum_Number_of_Non_overlapping_Palindrome_Substrings;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-non-overlapping-palindrome-substrings/submissions/842391089/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
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
