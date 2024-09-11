namespace LeetCode.Problems._2945_Find_Maximum_Non_decreasing_Array_Length;

/// <summary>
/// NotImplemented
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution7 : ISolution
{
    public int FindMaximumLength(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var dp = new (int length, long lastNum)[n + 1];

        for (var i = 1; i <= n; i++)
        {
            var minIndex = 0;
            var maxIndex = i - 1;

            while (minIndex <= maxIndex)
            {
                var midIndex = minIndex + (maxIndex - minIndex >> 1);
                var sum = prefixSums[i] - prefixSums[midIndex];

                if (sum >= nums[midIndex])
                {
                    minIndex = midIndex + 1;
                }
                else
                {
                    maxIndex = midIndex - 1;
                }
            }

            for (var j = maxIndex; j >= 0; j--)
            {
                var sum = prefixSums[i] - prefixSums[j];

                if (sum < dp[j].lastNum)
                {
                    continue;
                }

                dp[i] = (dp[j].length + 1, prefixSums[i] - prefixSums[j]);
                break;
            }

        }

        return dp[n].length;
    }
}
