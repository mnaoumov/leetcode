namespace LeetCode.Problems._2256_Minimum_Average_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/854275828/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinimumAverageDifference(int[] nums)
    {
        long total = 0;

        var runningTotals = nums.Select(num => total += num).ToArray();

        var sum = runningTotals[^1];
        var n = nums.Length;

        return runningTotals.Select((runningTotal, index) => (diff: Math.Abs(runningTotal / (index + 1) - (index == n - 1 ? 0 : (sum - runningTotal) / (n - 1 - index))), index)).Min().index;
    }
}
