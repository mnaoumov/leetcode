using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0069_Sqrt_x_;

/// <summary>
/// https://leetcode.com/submissions/detail/193809146/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int MySqrt(int x)
    {
        long result = 1;

        while (!(result * result <= x && (result + 1) * (result + 1) > x))
        {
            result = (result + (x / result)) / 2;
        }

        return (int)result;
    }
}