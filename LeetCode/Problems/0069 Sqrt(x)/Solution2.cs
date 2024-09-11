using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0069_Sqrt_x_;

/// <summary>
/// https://leetcode.com/submissions/detail/193353466/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MySqrt(int x)
    {
        var result = 1;

        while (!(result * result <= x && (result + 1) * (result + 1) > x))
        {
            result = (result + (x / result)) / 2;
        }

        return result;
    }
}
