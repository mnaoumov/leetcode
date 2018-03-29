using System;

namespace LeetCode.Problem001_TwoSum
{
    public class BruteForce : ISolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new[] { i, j };
                }
            }

            throw new ArgumentException();
        }
    }
}