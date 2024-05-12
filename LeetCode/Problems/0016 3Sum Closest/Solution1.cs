using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0016_3Sum_Closest;

/// <summary>
/// https://leetcode.com/submissions/detail/809285651/
/// </summary>
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        var minDistance = int.MaxValue;

        var result = 0;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
            {
                continue;
            }

            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                if (j > i + 1 && nums[j - 1] == nums[j])
                {
                    continue;
                }

                var preciseValue = target - nums[i] - nums[j];

                int GetClosestValue()
                {
                    if (preciseValue <= nums[i + 2])
                    {
                        return nums[i + 2];
                    }

                    if (preciseValue >= nums[^1])
                    {
                        return nums[^1];
                    }

                    var minIndex = i + 2;
                    var maxIndex = nums.Length - 1;

                    while (minIndex < maxIndex)
                    {
                        var k = (minIndex + maxIndex) / 2;

                        var value = nums[k];

                        if (value == preciseValue)
                        {
                            return value;
                        }

                        if (value < preciseValue)
                        {
                            minIndex = k;
                        }
                        else
                        {
                            maxIndex = k;
                        }
                    }

                    if (minIndex == nums.Length - 1)
                    {
                        return nums[^1];
                    }

                    var leftValue = nums[minIndex];
                    var rightValue = nums[minIndex + 1];

                    if (Math.Abs(leftValue - preciseValue) <= Math.Abs(rightValue - preciseValue))
                    {
                        return leftValue;
                    }

                    return rightValue;

                }

                var closestValue = GetClosestValue();

                var distance = preciseValue - closestValue;

                if (distance == 0)
                {
                    return target;
                }

                if (Math.Abs(distance) < minDistance)
                {
                    minDistance = Math.Abs(distance);
                    result = target - distance;
                }
            }
        }

        return result;
    }
}
