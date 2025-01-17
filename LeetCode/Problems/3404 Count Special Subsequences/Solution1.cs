namespace LeetCode.Problems._3404_Count_Special_Subsequences;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-430/submissions/detail/1491205972/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long NumberOfSubsequences(int[] nums)
    {
        var n = nums.Length;

        var counts = new Dictionary<(int numerator, int denominator), int>();

        var ans = 0L;

        for (var p = 0; p < n; p++)
        {
            for (var q = p + 2; q < n; q++)
            {
                for (var r = q + 2; r < n; r++)
                {
                    for (var s = r + 2; s < n; s++)
                    {
                        if (nums[p] * nums[r] == nums[q] * nums[s])
                        {
                            ans++;
                        }
                    }
                }
            }
        }

        return ans;
    }
}
