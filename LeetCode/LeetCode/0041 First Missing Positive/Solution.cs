namespace LeetCode._0041_First_Missing_Positive;

/// <summary>
/// https://leetcode.com/submissions/detail/814399148/
/// </summary>
public class Solution : ISolution
{
    public int FirstMissingPositive(int[] nums)
    {
        const int SeenNumber = 0;
        const int NumberToIgnore = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == SeenNumber)
            {
                nums[i] = NumberToIgnore;
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var j = nums[i];
            while (1 <= j && j <= nums.Length)
            {
                (j, nums[j - 1]) = (nums[j - 1], SeenNumber);

            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != SeenNumber)
            {
                return i + 1;
            }
        }

        return nums.Length + 1;
    }
}