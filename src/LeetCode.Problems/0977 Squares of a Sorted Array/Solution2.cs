namespace LeetCode.Problems._0977_Squares_of_a_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/854894444/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] SortedSquares(int[] nums)
    {
        var result = new int[nums.Length];
        var resultIndex = 0;

        var nonNegativeNumIndex = Array.BinarySearch(nums, 0);

        if (nonNegativeNumIndex < 0)
        {
            nonNegativeNumIndex = ~nonNegativeNumIndex;
        }

        var nonPositiveNumIndex = nonNegativeNumIndex - 1;

        while (nonNegativeNumIndex < nums.Length || nonPositiveNumIndex >= 0)
        {
            var num = int.MaxValue;

            if (nonNegativeNumIndex < nums.Length)
            {
                num = nums[nonNegativeNumIndex];
            }

            if (nonPositiveNumIndex >= 0 && -nums[nonPositiveNumIndex] < num)
            {
                num = nums[nonPositiveNumIndex];
                nonPositiveNumIndex--;
            }
            else
            {
                nonNegativeNumIndex++;
            }

            result[resultIndex] = num * num;
            resultIndex++;
        }

        return result;
    }
}
