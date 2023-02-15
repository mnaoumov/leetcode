using JetBrains.Annotations;

namespace LeetCode._0317_Shortest_Distance_from_All_Buildings;

/// <summary>
/// https://leetcode.com/submissions/detail/898005994/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ShortestDistance(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var hasEmptyLand = false;
        const int emptyLand = 0;
        const int building = 1;

        var queue = new Queue<(int distance, int buildingId, int i, int j)>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                switch (grid[i][j])
                {
                    case emptyLand:
                        hasEmptyLand = true;
                        break;
                    case building:
                        queue.Enqueue((0, queue.Count, i, j));
                        break;
                }
            }
        }

        const int impossible = -1;

        if (!hasEmptyLand)
        {
            return impossible;
        }

        var buildingsCount = queue.Count;

        var visited = new Dictionary<(int i, int j), Dictionary<int, int>>();

        var deltas = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var result = int.MaxValue;

        while (queue.Count > 0)
        {
            var (distance, buildingId, i, j) = queue.Dequeue();

            if (i < 0 || j < 0 || i >= m || j >= n)
            {
                continue;
            }

            if (distance > 0 && grid[i][j] != emptyLand)
            {
                continue;
            }

            if (grid[i][j] == emptyLand)
            {
                if (!visited.ContainsKey((i, j)))
                {
                    visited[(i, j)] = new Dictionary<int, int>();
                }

                if (visited[(i, j)].ContainsKey(buildingId))
                {
                    continue;
                }

                visited[(i, j)][buildingId] = distance;

                if (visited[(i, j)].Count == buildingsCount)
                {
                    result = Math.Min(result, visited[(i, j)].Values.Sum());
                }
            }

            foreach (var (di, dj) in deltas)
            {
                queue.Enqueue((distance + 1, buildingId, i + di, j + dj));
            }
        }

        return result == int.MaxValue ? impossible : result;
    }
}
