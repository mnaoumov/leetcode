namespace LeetCode.Problems._3809_Best_Reachable_Tower;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-174/problems/best-reachable-tower/submissions/1887839413/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] BestTower(int[][] towers, int[] center, int radius)
    {
        var bestTriplet = (inverseQuality: int.MaxValue, x: -1, y: -1);

        foreach (var tower in towers)
        {
            var dx = tower[0] - center[0];
            var dy = tower[1] - center[1];
            var distance = Math.Abs(dx) + Math.Abs(dy);
            var triplet = (inverseQuality: -tower[2], x: tower[0], y: tower[1]);

            if (distance <= radius && triplet.CompareTo(bestTriplet) < 0)
            {
                bestTriplet = triplet;
            }
        }

        return new[] { bestTriplet.x, bestTriplet.y };
    }
}
