using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205247734/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution03 : ISolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n < 0)
        {
            return MyPow(1 / x, -n);
        }

        var result = 1m;
        for (int i = 0; i < n; i++)
        {
            if (result == 0m)
            {
                break;
            }

            result *= (decimal) x;
        }

        return (double) result;
    }
}
