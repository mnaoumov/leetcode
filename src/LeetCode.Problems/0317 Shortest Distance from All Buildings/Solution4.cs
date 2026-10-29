namespace LeetCode.Problems._0317_Shortest_Distance_from_All_Buildings;

/// <summary>
/// https://leetcode.com/problems/shortest-distance-from-all-buildings/submissions/1592602710/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution4 : ISolution
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

        var visited = new Dictionary<(int i, int j), (HashSet<int> visitedBuildingIds, int totalDistance)>();

        var deltas = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var ans = int.MaxValue;

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
                visited.TryAdd((i, j), (new HashSet<int>(), 0));

                if (!visited[(i, j)].visitedBuildingIds.Add(buildingId))
                {
                    continue;
                }

                visited[(i, j)] = visited[(i, j)] with { totalDistance = visited[(i, j)].totalDistance + distance };

                if (visited[(i, j)].totalDistance >= ans)
                {
                    continue;
                }

                if (visited[(i, j)].visitedBuildingIds.Count == buildingsCount)
                {
                    ans = visited[(i, j)].totalDistance;
                }
            }

            foreach (var (di, dj) in deltas)
            {
                queue.Enqueue((distance + 1, buildingId, i + di, j + dj));
            }
        }

        return ans == int.MaxValue ? impossible : ans;
    }
}
