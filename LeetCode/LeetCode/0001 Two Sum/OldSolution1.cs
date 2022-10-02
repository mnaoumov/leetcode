namespace LeetCode._0001_Two_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/147383765/
/// </summary>
public class OldSolution1 : ISolution
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

        return new int[0];
    }
}