namespace LeetCode.Problems._0029_Divide_Two_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/829014964/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue)
        {
            return divisor switch
            {
                -1 => int.MaxValue,
                > 0 => -1 + Divide(dividend + divisor, divisor),
                _ => 1 + Divide(dividend - divisor, divisor)
            };
        }

        if (divisor == int.MinValue)
        {
            return 0;
        }

        if (dividend < 0)
        {
            if (divisor < 0)
            {
                return Divide(-dividend, -divisor);
            }

            return -Divide(-dividend, divisor);
        }

        if (divisor < 0)
        {
            return -Divide(dividend, -divisor);
        }

        var addendumQuotientPairs = new List<(int summand, int quotient)>();

        var addendum = divisor;
        var quotient = 1;

        while (addendum <= dividend)
        {
            addendumQuotientPairs.Insert(0, (addendum, quotient));

            if (addendum > int.MaxValue - addendum)
            {
                break;
            }

            addendum += addendum;
            quotient += quotient;
        }

        var result = 0;

        while (dividend >= divisor)
        {
            var maxPair = addendumQuotientPairs.First(p => p.summand <= dividend);
            dividend -= maxPair.summand;
            result += maxPair.quotient;
        }

        return result;
    }
}
