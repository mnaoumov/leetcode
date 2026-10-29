namespace LeetCode.Problems._2926_Maximum_Balanced_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/1091769604/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution5 : ISolution
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

            var index = diffs.BinarySearch(diff);

            if (index < 0)
            {
                index = ~index - 1;
                diffs.Insert(index + 1, diff);
            }

            if (index < 0)
            {
                maxSums[diff] = num;
            }
            else
            {
                maxSums[diff] = num + maxSums[diffs[index]];
            }

            ans = Math.Max(ans, maxSums[diff]);
        }

        return max < 0 ? max : ans;
    }
}
