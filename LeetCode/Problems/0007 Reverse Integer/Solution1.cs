

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0007_Reverse_Integer;

/// <summary>
/// https://leetcode.com/submissions/detail/148143600/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Reverse(int x)
    {
        var sign = Math.Sign(x);
        x = Math.Abs(x);
        var result = 0;
        while (x > 0)
        {
            var lastDigit = x % 10;
            try
            {
                result = checked(result * 10 + lastDigit);
            }
            catch (OverflowException)
            {
                return 0;
            }

            x = x / 10;
        }

        result = result * sign;

        return result;
    }
}
