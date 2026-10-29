using System.Text;

namespace LeetCode.Problems._0017_Letter_Combinations_of_a_Phone_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/918834678/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
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

        var result = new List<string>();
        var combination = new StringBuilder();
        Backtrack(0);
        return result;

        void Backtrack(int i)
        {
            if (i == digits.Length)
            {
                result.Add(combination.ToString());
                return;
            }

            var digit = digits[i] - '0';

            foreach (var letter in digitsToLettersMap[digit])
            {
                combination.Append(letter);
                Backtrack(i + 1);
                combination.Remove(combination.Length - 1, 1);
            }
        }
    }
}
