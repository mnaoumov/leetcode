using JetBrains.Annotations;

namespace LeetCode._1508_Range_Sum_of_Sorted_Subarray_Sums;

/// <summary>
/// https://leetcode.com/submissions/detail/950468416/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RangeSum(int[] nums, int n, int left, int right)
    {
        var sums = new List<int>();

        for (var i = 0; i < n; i++)
        {
            var sum = 0;
            for (var j = i; j < n; j++)
            {
                sum += nums[j];
                sums.Add(sum);
            }
        }

        sums.Sort();

        const int modulo = 1_000_000_007;

        var ans = 0;

        for (var i = left; i <= right; i++)
        {
            ans = (ans + sums[i - 1]) % modulo;
        }

        return ans;
    }
}
