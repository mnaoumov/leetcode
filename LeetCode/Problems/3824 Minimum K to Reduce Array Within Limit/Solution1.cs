namespace LeetCode.Problems._3824_Minimum_K_to_Reduce_Array_Within_Limit;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-175/problems/minimum-k-to-reduce-array-within-limit/submissions/1903151336/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumK(int[] nums)
    {
        var max = nums.Max();

        var low = 1;
        var high = max;

        while (low <= high)
        {
            var mid = (low + high) / 2;

            if (NonPositive(nums, mid) <= 1L * mid * mid)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    private static long NonPositive(int[] nums, int k) => nums.Select(num => 1L * (num + k - 1) / k).Sum();
}
