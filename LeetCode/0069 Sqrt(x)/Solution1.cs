using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0069_Sqrt_x_;

/// <summary>
/// https://leetcode.com/submissions/detail/193351695/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MySqrt(int x)
    {
        var result = x / 2;

        while (!(result * result <= x && (result + 1) * (result + 1) > x))
        {
            result = (result + (x / result)) / 2;
        }

        return result;
    }
}