using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0043_Multiply_Strings;

/// <summary>
/// https://leetcode.com/submissions/detail/814693471/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public string Multiply(string num1, string num2)
    {
        var digits1 = GetDigits(num1);
        var digits2 = GetDigits(num2);

        var resultDigits = new List<int> { 0 };

        var trailingZeros = new List<int>();

        foreach (var digit2 in digits2.Reverse<int>())
        {
            var productDigits = Multiply(digits1, digit2);
            productDigits.AddRange(trailingZeros);
            resultDigits = Add(resultDigits, productDigits);
            trailingZeros.Add(0);
        }

        return string.Join("", resultDigits);
    }

    private static List<int> Add(List<int> digits1, List<int> digits2)
    {
        var resultDigits = new List<int>();

        var i = 0;
        var curry = 0;

        while (true)
        {
            var digit1 = GetDigitFromEnd(digits1, i);
            var digit2 = GetDigitFromEnd(digits2, i);
            var digitsSum = digit1 + digit2 + curry;
            if (digitsSum == 0 && i >= digits1.Count && i >= digits2.Count)
            {
                break;
            }

            resultDigits.Insert(0, digitsSum % 10);
            curry = digitsSum / 10;
            i++;
        }

        if (resultDigits.Count == 0)
        {
            resultDigits.Add(0);
        }

        return resultDigits;
    }

    private static int GetDigitFromEnd(List<int> digits, int indexFromEnd) => indexFromEnd < digits.Count ? digits[digits.Count - 1 - indexFromEnd] : 0;

    private static List<int> Multiply(List<int> digits1, int digit2)
    {
        var resultDigits = new List<int>();

        var curry = 0;

        foreach (var digit1 in digits1.Reverse<int>())
        {
            var digitsProduct = digit1 * digit2 + curry;
            resultDigits.Insert(0, digitsProduct % 10);
            curry = digitsProduct / 10;
        }

        if (curry != 0)
        {
            resultDigits.Insert(0, curry);
        }

        return resultDigits;
    }

    private static List<int> GetDigits(string num) => num.ToCharArray().Select(symbol => symbol - '0').ToList();
}
