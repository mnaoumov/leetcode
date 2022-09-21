﻿namespace LeetCode._001_Two_Sum;

public class HashMapSolution : ISolution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var hashMap = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            hashMap[nums[i]] = i;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            var secondAddendum = target - nums[i];

            if (hashMap.TryGetValue(secondAddendum, out var secondAddendumIndex) && secondAddendumIndex > i)
            {
                return new[] { i, secondAddendumIndex };
            }
        }

        return null;
    }
}