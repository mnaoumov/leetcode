using JetBrains.Annotations;

namespace LeetCode.Problems._1611_Minimum_One_Bit_Operations_to_Make_Integers_Zero;

/// <summary>
/// https://leetcode.com/submissions/detail/1109850213/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumOneBitOperations(int n)
    {
        var ans = 0;

        const int maxBit = 29;

        for (var i = 0; i <= maxBit; i++)
        {
            if ((n & 1 << i) != 0)
            {
                ans ^= (1 << i + 1) - 1;
            }
        }

        return ans;
    }
}
