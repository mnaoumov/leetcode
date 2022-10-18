using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205250713/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution05 : ISolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0 || Math.Abs(x - 1.0) < double.Epsilon)
        {
            return 1;
        }

        if (n == int.MinValue)
        {
            return MyPow(1 / x, int.MaxValue) / x;
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

            result *= (decimal)x;
        }

        return (double)result;
    }
}