using JetBrains.Annotations;

namespace LeetCode.Problems._2090_K_Radius_Subarray_Averages;

/// <summary>
/// https://leetcode.com/submissions/detail/975182150/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetAverages(int[] nums, int k)
    {
        var n = nums.Length;
        var ans = Enumerable.Repeat(-1, n).ToArray();

        if (n <= 2 * k)
        {
            return ans;
        }

        var sum = nums.Take(2 * k + 1).Select(num => (long) num).Sum();

        for (var i = k; i < n - k; i++)
        {
            ans[i] = (int) (sum / (2 * k + 1));

            if (i == n - k - 1)
            {
                break;
            }

            sum -= nums[i - k];
            sum += nums[i + 1 + k];
        }

        return ans;
    }
}
