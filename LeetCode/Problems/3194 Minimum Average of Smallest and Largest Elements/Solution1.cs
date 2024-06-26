using JetBrains.Annotations;

namespace LeetCode.Problems._3194_Minimum_Average_of_Smallest_and_Largest_Elements;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-403/submissions/detail/1297228246/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double MinimumAverage(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;
        return Enumerable.Range(0, n / 2).Select(i => (nums[i] + nums[n - 1 - i]) / 2.0).Min();
    }
}
