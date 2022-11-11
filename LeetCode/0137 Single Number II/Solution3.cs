using JetBrains.Annotations;

namespace LeetCode._0137_Single_Number_II;

/// <summary>
/// https://leetcode.com/problems/single-number-ii/submissions/840152979/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int SingleNumber(int[] nums)
    {
        const int bitCount = 32;

        var bitCounts = new byte[bitCount];

        foreach (var num in nums)
        {
            for (var i = 0; i < bitCount; i++)
            {
                var bit = num >> i & 1;
                bitCounts[i] = (byte) ((bitCounts[i] + bit) % 3);
            }
        }

        var result = 0;

        for (var i = 0; i < bitCount; i++)
        {
            if (bitCounts[i] == 1)
            {
                result += 1 << i;
            }
        }

        return result;
    }
}
