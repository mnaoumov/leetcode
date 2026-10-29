namespace LeetCode.Problems._3678_Smallest_Absent_Positive_Greater_Than_Average;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-165/problems/smallest-absent-positive-greater-than-average/submissions/1769388939/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SmallestAbsent(int[] nums)
    {
        var avg = nums.Average();
        Array.Sort(nums);
        var minPositiveGreaterThanAverage = Math.Max((int) Math.Floor(avg) + 1, 1);
        var index = Array.BinarySearch(nums, minPositiveGreaterThanAverage);
        if (index < 0)
        {
            return minPositiveGreaterThanAverage;
        }

        while (index + 1 < nums.Length && (nums[index + 1] == nums[index] || nums[index + 1] == nums[index] + 1))
        {
            index++;
        }

        return nums[index] + 1;
    }
}
