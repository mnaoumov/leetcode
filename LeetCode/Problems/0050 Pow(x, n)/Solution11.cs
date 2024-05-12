using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/815851460/
/// </summary>
[UsedImplicitly]
public class Solution11 : ISolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0)
        {
            return 1d;
        }

        if (n == int.MinValue)
        {
            return MyPow(x, n + 1) / x;
        }

        if (n < 0)
        {
            return MyPow(1 / x, -n);
        }

        var y = MyPow(x, n / 2);

        var result = y * y;

        if (n % 2 == 1)
        {
            result *= x;
        }

        return result;
    }
}
