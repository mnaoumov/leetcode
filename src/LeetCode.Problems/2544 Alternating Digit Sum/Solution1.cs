namespace LeetCode.Problems._2544_Alternating_Digit_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-329/submissions/detail/882770186/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AlternateDigitSum(int n)
    {
        var result = 0;
        var sign = 1;

        while (n > 0)
        {
            var digit = n % 10;
            n /= 10;
            result += digit * sign;
            sign = -sign;
        }

        result *= -sign;

        return result;
    }
}
