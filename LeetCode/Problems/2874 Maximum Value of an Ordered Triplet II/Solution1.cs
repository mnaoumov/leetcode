using JetBrains.Annotations;

namespace LeetCode.Problems._2874_Maximum_Value_of_an_Ordered_Triplet_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-365/submissions/detail/1063616469/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaximumTripletValue(int[] nums)
    {
        var ans = 0L;
        var n = nums.Length;
        var minsBefore = new int[n];
        var maxesBefore = new int[n];
        var minsAfter = new int[n];
        var maxesAfter = new int[n];

        minsBefore[0] = int.MaxValue;
        maxesBefore[0] = int.MinValue;
        minsAfter[^1] = int.MaxValue;
        maxesAfter[^1] = int.MinValue;

        for (var j = 1; j < n - 1; j++)
        {
            minsBefore[j] = Math.Min(minsBefore[j - 1], nums[j - 1]);
            maxesBefore[j] = Math.Max(maxesBefore[j - 1], nums[j - 1]);
        }

        for (var j = n - 2; j >= 0; j--)
        {
            minsAfter[j] = Math.Min(minsAfter[j + 1], nums[j + 1]);
            maxesAfter[j] = Math.Max(maxesAfter[j + 1], nums[j + 1]);
        }

        for (var j = 1; j < n - 1; j++)
        {
            ans = Math.Max(ans, MaxProduct(minsBefore[j] - nums[j], j));
            ans = Math.Max(ans, MaxProduct(maxesBefore[j] - nums[j], j));
        }

        return ans;

        long MaxProduct(int multiplier, int j) => 1L * multiplier * (multiplier <= 0 ? minsAfter[j] : maxesAfter[j]);
    }
}
