namespace LeetCode.Problems._1840_Maximum_Building_Height;

/// <summary>
/// https://leetcode.com/problems/maximum-building-height/submissions/2039361671/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var maxHeights = new int[n + 1];
        Array.Fill(maxHeights, int.MaxValue);
        maxHeights[0] = 0;
        maxHeights[1] = 0;

        foreach (var restriction in restrictions)
        {
            var id = restriction[0];
            var maxHeight = restriction[1];

            maxHeights[id] = maxHeight;
        }

        for (var i = 2; i <= n; i++)
        {
            maxHeights[i] = Math.Min(maxHeights[i], maxHeights[i - 1] + 1);
        }

        for (var i = n - 1; i >= 1; i--)
        {
            maxHeights[i] = Math.Min(maxHeights[i], maxHeights[i + 1] + 1);
        }

        return maxHeights.Max();
    }
}
