using JetBrains.Annotations;

namespace LeetCode._0017_Letter_Combinations_of_a_Phone_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/829009158/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
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
            // ReSharper disable once StringLiteralTypo
            [7] = "pqrs",
            [8] = "tuv",
            // ReSharper disable once StringLiteralTypo
            [9] = "wxyz"
        };

        var letterCombinations = new[] { "" };

        return digits.Select(digitChar => digitChar - '0')
            .Aggregate(letterCombinations, (current, digit) => current.SelectMany(_ => digitsToLettersMap[digit], (letterCombination, letter) => letterCombination + letter)
                .ToArray());
    }
}