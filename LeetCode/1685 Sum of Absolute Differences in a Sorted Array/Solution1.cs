using JetBrains.Annotations;

namespace LeetCode._1685_Sum_of_Absolute_Differences_in_a_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1105753416/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetSumAbsoluteDifferences(int[] nums)
    {
        var n = nums.Length;

        var prefixSums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            ans[i] = prefixSums[n] - 2 * prefixSums[i] + (2 * i - n) * nums[i];
        }

        return ans;
    }
}
