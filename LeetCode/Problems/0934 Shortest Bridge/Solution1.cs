using JetBrains.Annotations;

namespace LeetCode.Problems._0934_Shortest_Bridge;

/// <summary>
/// https://leetcode.com/submissions/detail/926826172/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestBridge(int[][] grid)
    {
        var n = grid.Length;
        var island1 = new HashSet<(int i, int j)>();
        var island2 = new HashSet<(int i, int j)>();
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                if (island1.Count == 0)
                {
                    Dfs(i, j, island1);
                }
                else if (!island1.Contains((i, j)))
                {
                    Dfs(i, j, island2);
                    break;
                }
            }
        }

        if (island1.Count > island2.Count)
        {
            (island1, island2) = (island2, island1);
        }

        var queue = new Queue<(int i, int j)>();

        foreach (var (i, j) in island1)
        {
            queue.Enqueue((i, j));
        }

        var result = -1;
        var seen = new HashSet<(int i, int j)>();

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var _ = 0; _ < count; _++)
            {
                var (i, j) = queue.Dequeue();

                if (island2.Contains((i, j)))
                {
                    return result;
                }

                if (!seen.Add((i, j)))
                {
                    continue;
                }

                foreach (var (di, dj) in directions)
                {
                    var nextI = i + di;
                    var nextJ = j + dj;

                    if (nextI < 0 || nextJ < 0 || nextI >= n || nextJ == n)
                    {
                        continue;
                    }

                    if (seen.Contains((nextI, nextJ)))
                    {
                        continue;
                    }

                    queue.Enqueue((nextI, nextJ));
                }
            }

            result++;
        }

        return result;

        void Dfs(int i, int j, ISet<(int i, int j)> island)
        {
            island.Add((i, j));

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= n || nextJ == n)
                {
                    continue;
                }

                if (grid[nextI][nextJ] == 0)
                {
                    continue;
                }

                if (island.Contains((nextI, nextJ)))
                {
                    continue;
                }

                Dfs(nextI, nextJ, island);
            }
        }
    }
}
