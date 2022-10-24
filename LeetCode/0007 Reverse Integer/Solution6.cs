using JetBrains.Annotations;

namespace LeetCode._0007_Reverse_Integer;

/// <summary>
/// Digits
/// https://leetcode.com/problems/reverse-integer/submissions/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
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

            switch (x)
            {
                case > 0 when result > int.MaxValue - digitWithSign:
                case < 0 when result < int.MinValue - digitWithSign:
                    return 0;
                default:
                    result += digitWithSign;
                    x /= 10;
                    break;
            }
        }

        return result;
    }
}