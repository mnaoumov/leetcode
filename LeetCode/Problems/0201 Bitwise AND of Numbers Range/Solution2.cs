using JetBrains.Annotations;

namespace LeetCode._0201_Bitwise_AND_of_Numbers_Range;

/// <summary>
/// https://leetcode.com/submissions/detail/926887216/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int RangeBitwiseAnd(int left, int right)
    {
        var x = left;
        var y = right;
        var bit = 1;

        var result = 0;

        while (x > 0)
        {
            if ((x & 1) == 1 && y == x)
            {
                result |= bit;
            }

            x >>= 1;
            y >>= 1;
            bit <<= 1;
        }

        return result;
    }
}
