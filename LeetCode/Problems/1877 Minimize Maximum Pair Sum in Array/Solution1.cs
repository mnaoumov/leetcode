using JetBrains.Annotations;

namespace LeetCode._1877_Minimize_Maximum_Pair_Sum_in_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1100917095/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinPairSum(int[] nums)
    {
        Array.Sort(nums);

        var n = nums.Length;
        return Enumerable.Range(0, n / 2).Max(i => nums[i] + nums[^(i + 1)]);
    }
}
