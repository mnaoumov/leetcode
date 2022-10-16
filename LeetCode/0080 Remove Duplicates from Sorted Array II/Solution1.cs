﻿namespace LeetCode._0080_Remove_Duplicates_from_Sorted_Array_II;

/// <summary>
/// https://leetcode.com/submissions/detail/821757785/
/// </summary>
public class Solution1 : ISolution
{
    public int RemoveDuplicates(int[] nums)
    {
        var insertPosition = 0;

        foreach (var num in nums)
        {
            if (insertPosition < 2 || num != nums[insertPosition - 2])
            {
                nums[insertPosition] = num;
                insertPosition++;
            }
        }

        return insertPosition;
    }
}