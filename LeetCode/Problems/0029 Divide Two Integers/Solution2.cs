using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0029_Divide_Two_Integers;

/// <summary>
/// https://leetcode.com/submissions/detail/812352227/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
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

        while (summand <= dividend && summand <= int.MaxValue - summand)
        {
            summandQuotientPairs.Insert(0, (summand, quotient));
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
