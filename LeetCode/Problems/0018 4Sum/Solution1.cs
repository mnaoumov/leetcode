using JetBrains.Annotations;
using LeetCode.Base;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0018_4Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/810187230/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        Array.Sort(nums);

        var result = new List<IList<int>>();

        for (int i = 0; i < nums.Length - 3; i++)
        {
            if (ShouldSkipDuplicate(i, 0))
            {
                continue;
            }

            for (int j = i + 1; j < nums.Length - 2; j++)
            {
                if (ShouldSkipDuplicate(j, i + 1))
                {
                    continue;
                }

                for (int k = j + 1; k < nums.Length - 1; k++)
                {
                    if (ShouldSkipDuplicate(k, j + 1))
                    {
                        continue;
                    }

                    var expectedValue = target - nums[i] - nums[j] - nums[k];

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
