using JetBrains.Annotations;

namespace LeetCode._2256_Minimum_Average_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/854140513/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinimumAverageDifference(int[] nums)
    {
        long total = 0;

        var runningTotals = nums.Select(num => total += num).ToArray();

        var sum = runningTotals[^1];
        var n = nums.Length;

        return runningTotals.Take(n - 1).Select((runningTotal, index) => (diff: Math.Abs(runningTotal / (index + 1) - (sum - runningTotal) / (n - 1 - index)), index)).Min().index;
    }
}
