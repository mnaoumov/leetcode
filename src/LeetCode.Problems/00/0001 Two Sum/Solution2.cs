
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0001_Two_Sum;

/// <seealso href="https://leetcode.com/submissions/detail/147386823/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            dict[nums[i]] = i;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int j;
            if (dict.TryGetValue(target - nums[i], out j) && j != i)
            {
                return new[] { i, j };
            }
        }

        return new int[0];
    }
}
