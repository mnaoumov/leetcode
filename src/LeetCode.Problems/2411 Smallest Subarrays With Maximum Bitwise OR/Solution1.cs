namespace LeetCode.Problems._2411_Smallest_Subarrays_With_Maximum_Bitwise_OR;

/// <summary>
/// https://leetcode.com/problems/smallest-subarrays-with-maximum-bitwise-or/submissions/1715286423/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] SmallestSubarrays(int[] nums)
    {
        const int bitsCount = 31;

        var minIndexByBit = new int[bitsCount];

        const int unsetIndex = int.MaxValue;

        Array.Fill(minIndexByBit, unsetIndex);

        var n = nums.Length;
        var ans = new int[n];

        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];
            ans[i] = 1;

            for (var j = 0; j < bitsCount; j++)
            {
                if ((num & 1 << j) != 0)
                {
                    minIndexByBit[j] = i;
                }
                else if (minIndexByBit[j] != unsetIndex)
                {
                    ans[i] = Math.Max(ans[i], minIndexByBit[j] - i + 1);
                }
            }
        }

        return ans;
    }
}
