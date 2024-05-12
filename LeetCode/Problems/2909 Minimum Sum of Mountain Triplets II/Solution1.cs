using JetBrains.Annotations;

namespace LeetCode.Problems._2909_Minimum_Sum_of_Mountain_Triplets_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-368/submissions/detail/1081004265/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumSum(int[] nums)
    {
        var n = nums.Length;
        var leftMin = int.MaxValue;
        var leftMins = Enumerable.Repeat(int.MaxValue, n).ToArray();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (num > leftMin)
            {
                leftMins[i] = leftMin;
            }
            else
            {
                leftMin = num;
            }
        }

        var rightMin = int.MaxValue;
        var rightMins = Enumerable.Repeat(int.MaxValue, n).ToArray();

        for (var i = n - 1; i >= 0; i--)
        {
            var num = nums[i];

            if (num > rightMin)
            {
                rightMins[i] = rightMin;
            }
            else
            {
                rightMin = num;
            }
        }

        var minSum = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            if (leftMins[i] == int.MaxValue || rightMins[i] == int.MaxValue)
            {
                continue;
            }

            minSum = Math.Min(minSum, leftMins[i] + nums[i] + rightMins[i]);
        }

        return minSum == int.MaxValue ? -1 : minSum;
    }
}
