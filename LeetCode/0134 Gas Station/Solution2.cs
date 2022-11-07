using JetBrains.Annotations;

namespace LeetCode._0134_Gas_Station;

/// <summary>
/// https://leetcode.com/problems/gas-station/submissions/838933524/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        const int impossible = -1;

        var runningDiffSums = new int[gas.Length];

        var minRunningDiffSum = int.MaxValue;
        var minIndex = impossible;

        for (var i = 0; i < runningDiffSums.Length; i++)
        {
            runningDiffSums[i] = (i > 0 ? runningDiffSums[i - 1] : 0) + (gas[i] - cost[i]);

            if (runningDiffSums[i] >= minRunningDiffSum)
            {
                continue;
            }

            minRunningDiffSum = runningDiffSums[i];
            minIndex = i + 1;
        }

        if (runningDiffSums[^1] < 0)
        {
            return impossible;
        }

        if (minIndex == runningDiffSums.Length)
        {
            return 0;
        }

        var shift = runningDiffSums[^1] - minRunningDiffSum;

        return runningDiffSums.Take(minIndex).All(runningDiffSum => runningDiffSum + shift >= 0) ? minIndex : impossible;
    }
}
