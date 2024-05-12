using JetBrains.Annotations;

namespace LeetCode.Problems._2484_Count_Palindromic_Subsequences;

/// <summary>
/// https://leetcode.com/submissions/detail/855910283/
/// </summary>
[UsedImplicitly]
public class Solution9 : ISolution
{
    public int CountPalindromes(string s)
    {
        const int modulo = 1000000007;

        const int digitsCount = 10;

        var counts = new int[digitsCount];
        var suffixes = new int[s.Length, digitsCount, digitsCount];
        var prefixes = new int[s.Length, digitsCount, digitsCount];

        for (var i = 0; i < s.Length; i++)
        {
            var digit = s[i] - '0';

            if (i > 0)
            {
                for (var j = 0; j < digitsCount; j++)
                {
                    for (var k = 0; k < digitsCount; k++)
                    {
                        prefixes[i, j, k] = prefixes[i - 1, j, k];
                    }

                    prefixes[i, j, digit] += counts[j];
                }
            }

            counts[digit]++;
        }

        counts = new int[digitsCount];

        for (var i = s.Length - 1; i >= 0; i--)
        {
            var digit = s[i] - '0';

            if (i < s.Length - 1)
            {
                for (var j = 0; j < digitsCount; j++)
                {
                    for (var k = 0; k < digitsCount; k++)
                    {
                        suffixes[i, k, j] = suffixes[i + 1, k, j];
                    }

                    suffixes[i, digit, j] += counts[j];
                }
            }

            counts[digit]++;
        }

        var result = 0;

        for (var i = 2; i < s.Length - 2; i++)
        {
            for (var j = 0; j < digitsCount; j++)
            {
                for (var k = 0; k < digitsCount; k++)
                {
                    result = (int) ((result + 1L * prefixes[i - 1, j, k] * suffixes[i + 1, k, j]) % modulo);
                }
            }
        }

        return result;
    }
}
