

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205248986/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution04 : ISolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0 || Math.Abs(x - 1.0) < double.Epsilon)
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
