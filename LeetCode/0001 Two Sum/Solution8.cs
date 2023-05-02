using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0001_Two_Sum;

/// <summary>
/// Brute force
/// https://leetcode.com/submissions/detail/816978280/
/// </summary>
[UsedImplicitly]
public class Solution8 : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new[] { i, j };
                }
            }
        }

        throw new InvalidOperationException();
    }
}
