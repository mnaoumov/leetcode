using JetBrains.Annotations;

namespace LeetCode._0421_Maximum_XOR_of_Two_Numbers_in_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/891017172/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindMaximumXOR(int[] nums)
    {
        const int maxBit = 31;

        var result = 0;

        var shifts = new HashSet<(int level, int value)>();

        foreach (var num in nums)
        {
            var value = num;

            for (var i = 0; i <= maxBit; i++)
            {
                shifts.Add((i, value));
                value >>= 1;
            }
        }

        for (var i = maxBit; i >= 0; i--)
        {
            if (nums.Select(num => (num ^ result) >> i ^ 1).Any(shiftedValueWithXor => shifts.Contains((i, shiftedValueWithXor))))
            {
                result |= 1 << i;
            }
        }

        return result;
    }
}
