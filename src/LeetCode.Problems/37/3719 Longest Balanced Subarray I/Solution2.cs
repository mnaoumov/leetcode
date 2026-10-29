namespace LeetCode.Problems._3719_Longest_Balanced_Subarray_I;

/// <summary>
/// https://leetcode.com/problems/longest-balanced-subarray-i/submissions/1915167406/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int LongestBalanced(int[] nums)
    {
        var n = nums.Length;
        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i; j < n; j++)
            {
                var evenCounts = 0;
                var oddCounts = 0;
                var seen = new HashSet<int>();
                for (var k = i; k <= j; k++)
                {
                    var num = nums[k];

                    if (!seen.Add(num))
                    {
                        continue;
                    }

                    if (nums[k] % 2 == 0)
                    {
                        evenCounts++;
                    }
                    else
                    {
                        oddCounts++;
                    }
                }
                if (evenCounts == oddCounts)
                {
                    ans = Math.Max(ans, j - i + 1);
                }
            }
        }

        return ans;
    }
}
