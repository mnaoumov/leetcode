namespace LeetCode.Problems._3364_Minimum_Positive_Sum_Subarray;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-425/submissions/detail/1461249203/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSumSubarray(IList<int> nums, int l, int r)
    {
        var ans = int.MaxValue;

        for (var length = l; length <= r; length++)
        {
            var sum = nums.Take(length).Sum();

            if (sum > 0)
            {
                ans = Math.Min(ans, sum);
            }

            for (var j = length; j < nums.Count; j++)
            {
                sum += nums[j] - nums[j - length];
                if (sum > 0)
                {
                    ans = Math.Min(ans, sum);
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;
    }
}
