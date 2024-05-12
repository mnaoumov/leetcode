using JetBrains.Annotations;

namespace LeetCode.Problems._0041_First_Missing_Positive;

/// <summary>
/// https://leetcode.com/submissions/detail/814399148/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstMissingPositive(int[] nums)
    {
        const int seenNumber = 0;
        const int numberToIgnore = -1;

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == seenNumber)
            {
                nums[i] = numberToIgnore;
            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            var j = nums[i];
            while (1 <= j && j <= nums.Length)
            {
                (j, nums[j - 1]) = (nums[j - 1], seenNumber);

            }
        }

        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != seenNumber)
            {
                return i + 1;
            }
        }

        return nums.Length + 1;
    }
}
