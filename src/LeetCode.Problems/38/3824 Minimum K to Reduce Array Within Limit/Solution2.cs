namespace LeetCode.Problems._3824_Minimum_K_to_Reduce_Array_Within_Limit;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-175/problems/minimum-k-to-reduce-array-within-limit/submissions/1903175655/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumK(int[] nums)
    {
        var low = 1;
        var high = int.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

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
