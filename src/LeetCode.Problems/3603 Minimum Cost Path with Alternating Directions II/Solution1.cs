namespace LeetCode.Problems._3603_Minimum_Cost_Path_with_Alternating_Directions_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-160/problems/minimum-cost-path-with-alternating-directions-ii/submissions/1687352285/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public long MinCost(int m, int n, int[][] waitCost)
    {
        var queue = new Queue<(int row, int column, long cost)>();
        queue.Enqueue((0, 0, 0));

        var ans = long.MaxValue;

        while (queue.Count > 0)
        {
            var (row, column, cost) = queue.Dequeue();

            cost += 1L * (row + 1) * (column + 1);

            if (row == m - 1 && column == n - 1)
            {
                ans = Math.Min(ans, cost);
                continue;
            }

            if (row != 0 || column != 0)
            {
                cost += waitCost[row][column];
            }

            if (row < m - 1)
            {
                queue.Enqueue((row + 1, column, cost));
            }

            if (column < n - 1)
            {
                queue.Enqueue((row, column + 1, cost));
            }
        }

        return ans;
    }
}
