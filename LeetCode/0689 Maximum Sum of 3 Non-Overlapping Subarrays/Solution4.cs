using JetBrains.Annotations;

namespace LeetCode._0689_Maximum_Sum_of_3_Non_Overlapping_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/898713438/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        var sums = new int[n - k + 1];
        var maxSumsFromLeft = new (int sum, int minIndex)[n - k + 1];

        sums[0] = nums.Take(k).Sum();
        maxSumsFromLeft[0] = (sums[0], 0);

        for (var i = 1; i < sums.Length; i++)
        {
            sums[i] = sums[i - 1] + nums[i - 1 + k] - nums[i - 1];
            maxSumsFromLeft[i] = sums[i] <= maxSumsFromLeft[i - 1].sum ? maxSumsFromLeft[i - 1] : (sums[i], i);
        }

        var maxSumsFromRight = new (int sum, int minIndex)[n - k + 1];
        maxSumsFromRight[^1] = (sums[^1], sums.Length - 1);

        for (var i = sums.Length - 2; i >= 0; i--)
        {
            maxSumsFromRight[i] = sums[i] < maxSumsFromRight[i + 1].sum ? maxSumsFromRight[i + 1] : (sums[i], i);
        }

        var maxSum = 0;

        var result = new int[3];

        for (var index2 = k; index2 <= n - 2 * k; index2++)
        {
            var (sumLeft, minIndexLeft) = maxSumsFromLeft[index2 - k];
            var (sumRight, minIndexRight) = maxSumsFromRight[index2 + k];
            var totalSum = sumLeft + sums[index2] + sumRight;

            if (totalSum <= maxSum)
            {
                continue;
            }

            maxSum = totalSum;
            result = new[] { minIndexLeft, index2, minIndexRight };
        }

        return result;
    }
}
