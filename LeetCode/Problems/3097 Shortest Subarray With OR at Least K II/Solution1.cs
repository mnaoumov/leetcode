namespace LeetCode.Problems._3097_Shortest_Subarray_With_OR_at_Least_K_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1448127321/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSubarrayLength(int[] nums, int k)
    {
        if (k == 0)
        {
            return 1;
        }

        var ans = int.MaxValue;
        var i = 0;
        var n = nums.Length;
        const int maxBit = 32;
        var orBitCounts = new int[maxBit];

        for (var j = 0; j < n; j++)
        {
            var num = nums[j];
            var temp = num;
            var bitIndex = 0;
            while (temp > 0)
            {
                var bit = temp & 1;
                if (bit == 1)
                {
                    orBitCounts[bitIndex]++;
                }

                temp >>= 1;
                bitIndex++;
            }

            while (CalculateOr() >= k)
            {
                ans = Math.Min(ans, j - i + 1);
                temp = nums[i];
                i++;
                bitIndex = 0;
                while (temp > 0)
                {
                    var bit = temp & 1;
                    if (bit == 1)
                    {
                        orBitCounts[bitIndex]--;
                    }

                    temp >>= 1;
                    bitIndex++;
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;

        int CalculateOr()
        {
            var ans2 = 0;
            for (var bitIndex = 0; bitIndex < maxBit; bitIndex++)
            {
                if (orBitCounts[bitIndex] > 0)
                {
                    ans2 |= 1 << bitIndex;
                }
            }

            return ans2;
        }
    }
}
