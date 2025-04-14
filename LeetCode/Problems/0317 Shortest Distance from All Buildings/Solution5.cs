namespace LeetCode.Problems._0317_Shortest_Distance_from_All_Buildings;

/// <summary>
/// https://leetcode.com/problems/shortest-distance-from-all-buildings/submissions/1592625230/
/// </summary>
[UsedImplicitly]
public class Solution5 : ISolution
{
    public int ShortestDistance(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int emptyLand = 0;
        const int building = 1;
        const int impossible = -1;

        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var emptyLandEntries = new Dictionary<(int row, int column), EmptyLandEntry>();
        var buildingsCount = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] != building)
                {
                    continue;
                }

                Bfs(i, j);
                buildingsCount++;
            }
        }

        return emptyLandEntries.Values
            .Where(entry => entry.VisitedBuildingsCount == buildingsCount)
            .Select(entry => entry.TotalDistance)
            .DefaultIfEmpty(impossible)
            .Min();

        void Bfs(int buildingRow, int buildingColumn)
        {
            var queue = new Queue<(int row, int column)>();
            queue.Enqueue((buildingRow, buildingColumn));
            var distance = 0;
            var visited = new HashSet<(int row, int column)>();

            while (queue.Count > 0)
            {
                var count = queue.Count;
                for (var i = 0; i < count; i++)
                {
                    var (row, column) = queue.Dequeue();

                    if (row < 0 || column < 0 || row >= m || column >= n)
                    {
                        continue;
                    }

                    if (distance > 0)
                    {
                        if (grid[row][column] != emptyLand)
                        {
                            continue;
                        }

                        if (!visited.Add((row, column)))
                        {
                            continue;
                        }

                        if (!emptyLandEntries.TryGetValue((row, column), out var entry))
                        {
                            entry = new EmptyLandEntry();
                            emptyLandEntries[(row, column)] = entry;
                        }

                        entry.TotalDistance += distance;
                        entry.VisitedBuildingsCount++;
                    }

                    foreach (var (dRow, dColumn) in directions)
                    {
                        var newRow = row + dRow;
                        var newColumn = column + dColumn;
                        queue.Enqueue((newRow, newColumn));
                    }
                }

                distance++;
            }
        }
    }

    private class EmptyLandEntry
    {
        public int TotalDistance { get; set; }
        public int VisitedBuildingsCount { get; set; }
    }
}
