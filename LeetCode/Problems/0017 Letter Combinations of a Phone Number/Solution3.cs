// ReSharper disable StringLiteralTypo
using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0017_Letter_Combinations_of_a_Phone_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/809521193/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
        {
            return Array.Empty<string>();
        }

        var digitsToLettersMap = new Dictionary<int, string>
        {
            [2] = "abc",
            [3] = "def",
            [4] = "ghi",
            [5] = "jkl",
            [6] = "mno",
            [7] = "pqrs",
            [8] = "tuv",
            [9] = "wxyz"
        };

        var letterCombinations = new[] { "" };

        foreach (var digitChar in digits)
        {
            var digit = digitChar - '0';
            letterCombinations = letterCombinations
                .SelectMany(_ => digitsToLettersMap[digit],
                    (letterCombination, letter) => letterCombination + letter)
                .ToArray();
        }

        return letterCombinations;
    }
}
