namespace LeetCode.Problems._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/829025823/
/// </summary>
[UsedImplicitly]
public class Solution12 : ISolution
{
    public double MyPow(double x, int n)
    {
        while (true)
        {
            switch (n)
            {
                case 0:
                    return 1d;
                case int.MinValue:
                    return MyPow(x, n + 1) / x;
                case < 0:
                    x = 1 / x;
                    n = -n;
                    continue;
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
}
