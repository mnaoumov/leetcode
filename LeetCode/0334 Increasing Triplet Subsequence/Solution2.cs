﻿namespace LeetCode._0334_Increasing_Triplet_Subsequence;

/// <summary>
/// 
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IncreasingTriplet(int[] nums)
    {
        if (nums.Length < 3)
        {
            return false;
        }

        var middleValuesSet = new HashSet<int>();

        for (var j = 1; j < nums.Length - 1; j++)
        {
            if (!middleValuesSet.Add(nums[j]))
            {
                continue;
            }

            if (Enumerable.Range(0, j).Any(i => nums[i] < nums[j]) && Enumerable.Range(j + 1, nums.Length - j - 1).Any(k => nums[j] < nums[k]))
            {
                return true;
            }
        }

        return false;
    }
}