using JetBrains.Annotations;

namespace LeetCode.Problems._0862_Shortest_Subarray_with_Sum_at_Least_K;

/// <summary>
/// https://leetcode.com/submissions/detail/950450851/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestSubarray(int[] nums, int k)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var ans = int.MaxValue;
        var increasingPrefixIndices = new LinkedList<int>();

        for (var y = 0; y < n + 1; y++)
        {
            while (increasingPrefixIndices.Count > 0 && prefixSums[y] <= prefixSums[increasingPrefixIndices.Last!.Value])
            {
                increasingPrefixIndices.RemoveLast();
            }

            while (increasingPrefixIndices.Count > 0 && prefixSums[y] >= prefixSums[increasingPrefixIndices.First!.Value] + k)
            {
                ans = Math.Min(ans, y - increasingPrefixIndices.First!.Value);
                increasingPrefixIndices.RemoveFirst();
            }

            increasingPrefixIndices.AddLast(y);
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
