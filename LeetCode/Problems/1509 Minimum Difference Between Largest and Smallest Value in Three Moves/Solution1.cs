namespace LeetCode.Problems._1509_Minimum_Difference_Between_Largest_and_Smallest_Value_in_Three_Moves;

/// <summary>
/// https://leetcode.com/submissions/detail/1307746820/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinDifference(int[] nums)
    {
        var n = nums.Length;

        if (n <= 3)
        {
            return 0;
        }

        Array.Sort(nums);

        return Enumerable.Range(0, 4).Select(i => nums[^(4 - i)] - nums[i]).Min();
    }
}
