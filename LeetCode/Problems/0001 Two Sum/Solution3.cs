
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0001_Two_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/147393932/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int index = 0; index < nums.Length; index++)
        {
            int complementIndex;
            var currentValue = nums[index];
            var complementValue = target - currentValue;
            if (dict.TryGetValue(complementValue, out complementIndex))
            {
                return new[] { complementIndex, index };
            }

            dict[currentValue] = index;
        }

        return new int[0];
    }
}
