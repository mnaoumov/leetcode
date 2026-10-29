namespace LeetCode.Problems._2016_Maximum_Difference_Between_Increasing_Elements;

/// <summary>
/// https://leetcode.com/problems/maximum-difference-between-increasing-elements/submissions/1665431935/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaximumDifference(int[] nums)
    {
        var min = int.MaxValue;
        var ans = -1;

        foreach (var num in nums)
        {
            if (num > min)
            {
                ans = Math.Max(ans, num - min);
            }
            else
            {
                min = num;
            }
        }

        return ans;
    }
}
