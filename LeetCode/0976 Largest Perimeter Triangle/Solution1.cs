namespace LeetCode._0976_Largest_Perimeter_Triangle;

/// <summary>
/// https://leetcode.com/submissions/detail/820559586/
/// </summary>
public class Solution1 : ISolution
{
    public int LargestPerimeter(int[] nums)
    {
        Array.Sort(nums);

        for (var i = nums.Length - 1; i >= 2; i--)
        {
            if (nums[i] < nums[i - 1] + nums[i - 2])
            {
                return nums[i] + nums[i - 1] + nums[i - 2];
            }
        }

        return 0;
    }
}