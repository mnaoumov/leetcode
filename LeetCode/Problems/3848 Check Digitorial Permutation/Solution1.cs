namespace LeetCode.Problems._3848_Check_Digitorial_Permutation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-490/problems/check-digitorial-permutation/submissions/1926908862/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsDigitorialPermutation(int n)
    {
        const int digitsCount = 10;
        var factorials = new int[digitsCount];
        factorials[0] = 1;

        for (var digit = 1; digit < digitsCount; digit++)
        {
            factorials[digit] = factorials[digit - 1] * digit;
        }

        var digits = GetDigits(n);
        var digitFactorialsSum = digits.Select(digit => factorials[digit]).Sum();
        var sumDigits = GetDigits(digitFactorialsSum);

        if (sumDigits.Count != digits.Count)
        {
            return false;
        }

        var digitsSorted = digits.OrderBy(d => d);
        var sumDigitsSorted = sumDigits.OrderBy(d => d);

        return digitsSorted.SequenceEqual(sumDigitsSorted);
    }

    private static List<int> GetDigits(int n)
    {
        var digits = new List<int>();

        while (n > 0)
        {
            digits.Insert(0, n % 10);
            n /= 10;
        }

        return digits;
    }
}
