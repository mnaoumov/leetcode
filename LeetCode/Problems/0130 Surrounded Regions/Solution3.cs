using JetBrains.Annotations;

namespace LeetCode._0130_Surrounded_Regions;

/// <summary>
/// https://leetcode.com/problems/surrounded-regions/submissions/836868105/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    private const char Cross = 'X';

    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        var queue = new Queue<(int x, int y)>();

        var visited = new HashSet<(int x, int y)>();
        var noughtsToKeep = new HashSet<(int x, int y)>();
        var deltas = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        for (var i = 0; i < m; i++)
        {
            queue.Enqueue((i, 0));
            queue.Enqueue((i, n - 1));
        }

        for (var j = 0; j < n; j++)
        {
            queue.Enqueue((0, j));
            queue.Enqueue((m - 1, j));
        }

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();

            if (x < 0 || x >= m || y < 0 || y >= n)
            {
                continue;
            }

            if (board[x][y] == Cross)
            {
                continue;
            }

            if (!visited.Add((x, y)))
            {
                continue;
            }

            if (x == 0 || x == m - 1 || y == 0 || y == n - 1)
            {
                noughtsToKeep.Add((x, y));
            }
            else
            {
                foreach (var (dx, dy) in deltas)
                {
                    if (!noughtsToKeep.Contains((x + dx, y + dy)))
                    {
                        continue;
                    }

                    noughtsToKeep.Add((x, y));
                    break;
                }
            }

            foreach (var (dx, dy) in deltas)
            {
                queue.Enqueue((x + dx, y + dy));
            }
        }

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (!noughtsToKeep.Contains((i, j)))
                {
                    board[i][j] = Cross;
                }
            }
        }
    }
}
