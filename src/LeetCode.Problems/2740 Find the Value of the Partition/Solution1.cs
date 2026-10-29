namespace LeetCode.Problems._2740_Find_the_Value_of_the_Partition;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-350/submissions/detail/973687078/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindValueOfPartition(int[] nums)
    {
        Array.Sort(nums);

        var ans = int.MaxValue;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            ans = Math.Min(ans, nums[i + 1] - nums[i]);
        }

        return ans;
    }
}
