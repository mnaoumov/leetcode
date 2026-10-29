namespace LeetCode.Problems._3282_Reach_End_of_Array_With_Max_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382738913/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long FindMaximumScore(IList<int> nums)
    {
        var ans = 0L;
        var n = nums.Count;

        var lastIndex = 0;

        for (var i = 1; i < n; i++)
        {
            if (i < n -1 && nums[i] <= nums[lastIndex])
            {
                continue;
            }

            ans += 1L * nums[lastIndex] * (i - lastIndex);
            lastIndex = i;
        }

        return ans;
    }
}
