using JetBrains.Annotations;

namespace LeetCode.Problems._2498_Frog_Jump_II;

/// <summary>
/// https://leetcode.com/submissions/detail/858367824/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxJump(int[] stones)
    {
        var forwardStoneIndex = 0;
        var returnStoneIndex = 0;
        var cost = 0;

        var n = stones.Length;

        for (var i = 1; i < n - 1; i++)
        {
            var takeCost = Math.Max(stones[i] - stones[forwardStoneIndex],
                stones[i + 1] - stones[returnStoneIndex]);
            var skipCost = Math.Max(stones[i + 1] - stones[forwardStoneIndex],
                stones[i] - stones[returnStoneIndex]);

            if (skipCost < takeCost)
            {
                cost = Math.Max(cost, skipCost);
                returnStoneIndex = i;
            }
            else
            {
                cost = Math.Max(cost, takeCost);
                forwardStoneIndex = i;
            }
        }

        cost = new[]
            { cost, stones[n - 1] - stones[forwardStoneIndex], stones[n - 1] - stones[returnStoneIndex] }.Max();

        return cost;
    }
}
