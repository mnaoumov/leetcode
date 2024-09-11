
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205251719/
/// </summary>
[UsedImplicitly]
public class Solution07 : ISolution
{
    public double MyPow(double x, int n)
    {
        return (double) MyPow((decimal) x, n);
    }

    private decimal MyPow(decimal x, int n)
    {
        if (n == 0 || x == 1m)
        {
            return 1m;
        }

        if (x == -1)
        {
            return n % 2 == 0 ? 1 : -1;
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

            result *= x;
        }

        return result;
    }
}
