using JetBrains.Annotations;

namespace LeetCode._2908_Minimum_Sum_of_Mountain_Triplets_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-368/submissions/detail/1080977523/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSum(int[] nums)
    {
        var n = nums.Length;

        var minSum = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                for (var k = j + 1; k < n; k++)
                {
                    if (nums[i] < nums[j] && nums[k] < nums[j])
                    {
                        minSum = Math.Min(minSum, nums[i] + nums[j] + nums[k]);
                    }
                }
            }
        }

        return minSum == int.MaxValue ? -1 : minSum;
    }
}
