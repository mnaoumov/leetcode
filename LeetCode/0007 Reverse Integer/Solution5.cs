using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0007_Reverse_Integer;

/// <summary>
/// Digits
/// https://leetcode.com/submissions/detail/807901371/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int Reverse(int x)
    {
        var result = 0;

        while (x != 0)
        {
            var digitWithSign = x % 10;

            if (result is > int.MaxValue / 10 or < int.MinValue / 10)
            {
                return 0;
            }

            result *= 10;

            if (x > 0 && result > int.MaxValue - digitWithSign)
            {
                return 0;
            }

            if (x < 0 && result < int.MinValue - digitWithSign)
            {
                return 0;
            }

            result += digitWithSign;
            x /= 10;
        }

        return result;
    }
}
