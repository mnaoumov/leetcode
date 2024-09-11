
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205253229/
/// </summary>
[UsedImplicitly]
public class Solution08 : ISolution
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

        const int maxPowerOfTwo = 31;
        var powersOfTwo = new decimal[maxPowerOfTwo];
        powersOfTwo[0] = x;

        var power = 1;
        int i = 1;

        while (power <= n)
        {
            powersOfTwo[i] = powersOfTwo[i - 1] * powersOfTwo[i - 1];

            if (powersOfTwo[i] == 0)
            {
                return 0;
            }

            power *= 2;
            i++;
        }

        var result = 1m;
        i = 0;

        while (n > 0)
        {
            if (n % 2 == 1)
            {
                result *= powersOfTwo[i];
            }
            n /= 2;
            i++;
        }


        return result;
    }
}
