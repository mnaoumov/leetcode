namespace LeetCode.Problems._3622_Check_Divisibility_by_Digit_Sum_and_Product;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckDivisibility(int n)
    {
        var digits = GetDigits(n).ToArray();
        var digitSum = digits.Sum();
        var digitProd = digits.Aggregate((a, b) => a * b);
        return n % (digitSum + digitProd) == 0;
    }

    private static IEnumerable<int> GetDigits(int n)
    {
        if (n == 0)
        {
            yield return 0;
            yield break;
        }

        while (n > 0)
        {
            var digit = n % 10;
            yield return digit;
            n /= 10;
        }
    }
}
