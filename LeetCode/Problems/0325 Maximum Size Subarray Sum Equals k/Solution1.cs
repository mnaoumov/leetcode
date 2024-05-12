using JetBrains.Annotations;

namespace LeetCode.Problems._0325_Maximum_Size_Subarray_Sum_Equals_k;

/// <summary>
/// https://leetcode.com/submissions/detail/943287760/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSubArrayLen(int[] nums, int k)
    {
        var n = nums.Length;
        var minIndices = new Dictionary<int, int>
        {
            [0] = -1
        };

        var ans = 0;

        var prefixSum = 0;

        for (var i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            minIndices.TryAdd(prefixSum, i);

            if (minIndices.TryGetValue(prefixSum - k, out var minIndex))
            {
                ans = Math.Max(ans, i - minIndex);
            }
        }

        return ans;
    }
}
