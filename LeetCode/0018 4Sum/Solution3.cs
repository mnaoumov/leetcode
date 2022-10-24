﻿using JetBrains.Annotations;

namespace LeetCode._0018_4Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/829009435/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();

        for (var i = 0; i < nums.Length - 3; i++)
        {
            if (ShouldSkipDuplicate(i, 0))
            {
                continue;
            }

            for (var j = i + 1; j < nums.Length - 2; j++)
            {
                if (ShouldSkipDuplicate(j, i + 1))
                {
                    continue;
                }

                for (var k = j + 1; k < nums.Length - 1; k++)
                {
                    if (ShouldSkipDuplicate(k, j + 1))
                    {
                        continue;
                    }

                    var expectedValueLong = (long) target - nums[i] - nums[j] - nums[k];

                    if (expectedValueLong is < int.MinValue or > int.MaxValue)
                    {
                         continue;
                    }

                    var expectedValue = (int) expectedValueLong;


                    if (expectedValue < nums[k])
                    {
                        continue;
                    }

                    if (Array.BinarySearch(nums, k + 1, nums.Length - 1 - k, expectedValue) > 0)
                    {
                        result.Add(new[] { nums[i], nums[j], nums[k], expectedValue });
                    }
                }
            }
        }

        return result;

        bool ShouldSkipDuplicate(int i, int lowerBound)
        {
            return i > lowerBound && nums[i - 1] == nums[i];
        }
    }
}