namespace LeetCode.Problems._2210_Count_Hills_and_Valleys_in_an_Array;

/// <summary>
/// https://leetcode.com/problems/count-hills-and-valleys-in-an-array/submissions/1712958111/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountHillValley(int[] nums)
    {
        nums = nums.Distinct().ToArray();

        var m = nums.Length;

        var ans = 0;

        for (var i = 1; i < m-1; i++)
        {
            if (nums[i] < nums[i-1] && nums[i] < nums[i+1] ||
                nums[i] > nums[i-1] && nums[i] > nums[i+1])
            {
                ans++;
            }
        }

        return ans;
    }
}
