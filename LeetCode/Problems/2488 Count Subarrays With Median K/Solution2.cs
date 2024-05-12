using JetBrains.Annotations;

namespace LeetCode.Problems._2488_Count_Subarrays_With_Median_K;

/// <summary>
/// https://leetcode.com/submissions/detail/855921076/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var balancesCounts = new Dictionary<int, int>
        {
            [0] = 1
        };

        var result = 0;

        var index = Array.IndexOf(nums, k);

        var balance = 0;

        for (var i = 0; i < n; i++)
        {
            balance += Math.Sign(nums[i] - k);

            if (i < index)
            {
                balancesCounts[balance] = balancesCounts.GetValueOrDefault(balance) + 1;
            }
            else
            {
                result += balancesCounts.GetValueOrDefault(balance) + balancesCounts.GetValueOrDefault(balance - 1);
            }
        }

        return result;
    }
}
