using JetBrains.Annotations;

namespace LeetCode._2926_Maximum_Balanced_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1091776435/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution6 : ISolution
{
    public long MaxBalancedSubsequenceSum(int[] nums)
    {
        var n = nums.Length;

        var max = nums[0];
        var diffs = new List<int>();
        var maxSums = new Dictionary<int, long>();
        var ans = 0L + nums[0];

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            max = Math.Max(max, num);

            if (num < 0)
            {
                continue;
            }

            var diff = num - i;

            var diffIndex = diffs.BinarySearch(diff);
            var isNewDiff = diffIndex < 0;

            if (isNewDiff)
            {
                diffIndex = ~diffIndex;
                diffs.Insert(diffIndex, diff);
            }

            if (isNewDiff && diffIndex == 0)
            {
                maxSums[diff] = num;
            }
            else
            {
                maxSums[diff] = num + maxSums[diffs[isNewDiff ? diffIndex - 1 : diffIndex]];
            }

            for (var j = diffIndex + 1; j < diffs.Count; j++)
            {
                var nextDiff = diffs[j];

                if (maxSums[nextDiff] >= maxSums[diff])
                {
                    break;
                }

                maxSums[nextDiff] = maxSums[diff];
            }

            ans = Math.Max(ans, maxSums[diff]);
        }

        return max < 0 ? max : ans;
    }
}
