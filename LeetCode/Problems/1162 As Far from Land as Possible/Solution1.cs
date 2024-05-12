using JetBrains.Annotations;

namespace LeetCode.Problems._1162_As_Far_from_Land_as_Possible;

/// <summary>
/// https://leetcode.com/submissions/detail/895369268/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxDistance(int[][] grid)
    {
        var hasWater = false;
        var queue = new Queue<(int x, int y, int step)>();
        var visited = new HashSet<(int x, int y)>();
        const int land = 1;
        var n = grid.Length;

        for (var x = 0; x < n; x++)
        {
            for (var y = 0; y < n; y++)
            {
                if (grid[x][y] == land)
                {
                    queue.Enqueue((x, y, 0));
                }
                else
                {
                    hasWater = true;
                }
            }
        }

        if (queue.Count == 0 || !hasWater)
        {
            return -1;
        }

        var result = 0;

        while (queue.Count > 0)
        {
            var (x, y, step) = queue.Dequeue();

            if (x >= n || y >= n)
            {
                continue;
            }

            if (!visited.Add((x, y)))
            {
                continue;
            }

            if (grid[x][y] == land && step > 0)
            {
                continue;
            }

            result = step;

            queue.Enqueue((x + 1, y, step + 1));
            queue.Enqueue((x, y + 1, step + 1));
        }

        return result;
    }
}
