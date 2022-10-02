﻿namespace LeetCode._026_Remove_Duplicates_from_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/811558778/
/// </summary>
public class Solution : ISolution
{
    public int RemoveDuplicates(int[] nums)
    {
        var index = 0;
        var count = 0;
        int? lastValue = null;

        foreach (var num in nums)
        {
            if (num != lastValue)
            {
                nums[index] = num;
                lastValue = num;
                index++;
                count++;
            }
        }

        return count;
    }
}