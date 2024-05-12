using JetBrains.Annotations;

namespace LeetCode.Problems._0190_Reverse_Bits;

/// <summary>
/// https://leetcode.com/submissions/detail/923300142/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public uint reverseBits(uint n)
    {
        uint result = 0;

        for (var i = 0; i < 32; i++)
        {
            var bit = n & 1;
            result <<= 1;
            result |= bit;
            n >>= 1;
        }

        return result;
    }
}
