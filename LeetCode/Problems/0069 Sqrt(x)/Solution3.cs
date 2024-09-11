using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0069_Sqrt_x_;

/// <summary>
/// https://leetcode.com/submissions/detail/193354463/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MySqrt(int x)
    {
        double temp = x / 2.0;
        int floor;
        int ceil;

        do
        {
            floor = (int) Math.Floor(temp);
            ceil = floor + 1;
            temp = (temp + (x / temp)) / 2;
        } while (floor * floor > x || ceil * ceil <= x);

        while (!(temp * temp <= x && (temp + 1) * (temp + 1) > x))
        {
            temp = (temp + (x / temp)) / 2;
        }

        return floor;
    }
}
