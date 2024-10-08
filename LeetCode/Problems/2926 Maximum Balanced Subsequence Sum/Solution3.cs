namespace LeetCode.Problems._2926_Maximum_Balanced_Subsequence_Sum;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-370/submissions/detail/1091759331/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public long MaxBalancedSubsequenceSum(int[] nums)
    {
        var n = nums.Length;

        var max = nums[0];
        var stack = new Stack<(int diff, long maxSum)>();
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
            var maxSum = 0L;

            while (stack.Count > 0 && stack.Peek().diff < diff)
            {
                maxSum = Math.Max(maxSum, stack.Pop().maxSum);
            }

            stack.Push((diff, num + maxSum));
            ans = Math.Max(ans, num + maxSum);
        }

        return max < 0 ? max : ans;
    }
}
