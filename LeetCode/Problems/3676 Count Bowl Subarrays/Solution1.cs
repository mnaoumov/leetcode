namespace LeetCode.Problems._3676_Count_Bowl_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-466/problems/count-bowl-subarrays/submissions/1762178345/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long BowlSubarrays(int[] nums)
    {
        var n = nums.Length;

        var ans = 0;

        for (var i = 0; i < n - 2; i++)
        {
            var max = int.MinValue;

            for (var j = i + 1; j < n - 1; j++)
            {
                max = Math.Max(max, nums[j]);

                if (max > nums[i])
                {
                    break;
                }

                if (nums[j + 1] > max)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
