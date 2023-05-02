using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0001_Two_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/147386823/
/// </summary>
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
