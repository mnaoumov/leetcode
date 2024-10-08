
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0029_Divide_Two_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/812354082/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int Divide(int dividend, int divisor)
    {
        if (dividend == int.MinValue)
        {
            if (divisor == -1)
            {
                return int.MaxValue;
            }

            if (divisor > 0)
            {
                return -1 + Divide(dividend + divisor, divisor);
            }

            return 1 + Divide(dividend - divisor, divisor);
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

        var summandQuotientPairs = new List<(int summand, int quotient)>();

        var summand = divisor;
        var quotient = 1;

        while (summand <= dividend)
        {
            summandQuotientPairs.Insert(0, (summand, quotient));

            if (summand > int.MaxValue - summand)
            {
                break;
            }

            summand += summand;
            quotient += quotient;
        }

        var result = 0;

        while (dividend >= divisor)
        {
            var maxPair = summandQuotientPairs.First(p => p.summand <= dividend);
            dividend -= maxPair.summand;
            result += maxPair.quotient;
        }

        return result;
    }
}
