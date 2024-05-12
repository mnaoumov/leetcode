using JetBrains.Annotations;

namespace LeetCode._0417_Pacific_Atlantic_Water_Flow;

/// <summary>
/// https://leetcode.com/submissions/detail/925453495/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var m = heights.Length;
        var n = heights[0].Length;

        var result = new List<IList<int>>();
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var queue = new Queue<(int i, int j, Ocean ocean)>();
        var seen = new HashSet<(int i, int j, Ocean ocean)>();
        var candidates = new Dictionary<(int i, int j), HashSet<Ocean>>();

        for (var i = 0; i < m; i++)
        {
            queue.Enqueue((i, 0, Ocean.Pacific));
            queue.Enqueue((i, n - 1, Ocean.Atlantic));
        }

        for (var j = 0; j < n; j++)
        {
            queue.Enqueue((0, j, Ocean.Pacific));
            queue.Enqueue((m - 1, j, Ocean.Atlantic));
        }

        while (queue.Count > 0)
        {
            var (i, j, ocean) = queue.Dequeue();

            if (!seen.Add((i, j, ocean)))
            {
                continue;
            }

            if (!candidates.ContainsKey((i, j)))
            {
                candidates[(i, j)] = new HashSet<Ocean>();
            }

            candidates[(i, j)].Add(ocean);

            if (candidates[(i, j)].Count == 2)
            {
                result.Add(new[] { i, j });
            }

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                if (heights[nextI][nextJ] < heights[i][j])
                {
                    continue;
                }

                queue.Enqueue((nextI, nextJ, ocean));
            }
        }

        return result;
    }

    private enum Ocean
    {
        Pacific,
        Atlantic
    }
}
