using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2617_Minimum_Number_of_Visited_Cells_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/930545464/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinimumVisitedCells(int[][] grid)
    {
        var queue = new Queue<(int i, int j)>();
        queue.Enqueue((0, 0));

        var m = grid.Length;
        var n = grid[0].Length;

        var result = 1;

        int count;

        var seen = new HashSet<(int i, int j)>();

        while ((count = queue.Count) > 0)
        {
            for (var l = 0; l < count; l++)
            {
                var (i, j) = queue.Dequeue();

                if ((i, j) == (m - 1, n - 1))
                {
                    return result;
                }

                if (!seen.Add((i, j)))
                {
                    continue;
                }

                for (var k = j + 1; k <= Math.Min(j + grid[i][j], n - 1); k++)
                {
                    queue.Enqueue((i, k));
                }

                for (var k = i + 1; k <= Math.Min(i + grid[i][j], m - 1); k++)
                {
                    queue.Enqueue((k, j));
                }
            }

            result++;
        }

        return -1;
    }
}
