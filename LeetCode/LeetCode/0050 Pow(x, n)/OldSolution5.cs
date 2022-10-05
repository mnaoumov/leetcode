namespace LeetCode._0050_Pow_x__n_;

/// <summary>
/// https://leetcode.com/submissions/detail/205255390/
/// </summary>
public class OldSolution5 : ISolution
{
    public double MyPow(double x, int n)
    {
        if (n == 0 || Math.Abs(x - 1) < double.Epsilon)
        {
            return 1;
        }

        if (Math.Abs(x + 1) < double.Epsilon)
        {
            return n % 2 == 0 ? 1 : -1;
        }

        if (n == int.MinValue)
        {
            return 1 / MyPow(x, Int32.MaxValue) / x;
        }

        if (n < 0)
        {
            return 1 / MyPow(x, -n);
        }

        var y = MyPow(x, n / 2);
        return y * y * (n % 2 == 0 ? 1 : x);
    }
}