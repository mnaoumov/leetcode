namespace LeetCode.Problems._0959_Regions_Cut_By_Slashes;

/// <summary>
/// https://leetcode.com/submissions/detail/1350551302/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RegionsBySlashes(string[] grid)
    {
        var n = grid.Length;
        var m = 3 * n;

        var matrix = new bool[m, m];

        var borderDirectionsMap = new Dictionary<char, (int dRow, int dColumn)[]>
        {
            [' '] = Array.Empty<(int dRow, int dColumn)>(),
            ['/'] = new (int dRow, int dColumn)[] { (0, 2), (1, 1), (2, 0) },
            ['\\'] = new (int dRow, int dColumn)[] { (0, 0), (1, 1), (2, 2) }
        };

        for (var row = 0; row < n; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var symbol = grid[row][column];
                foreach (var (dRow, dColumn) in borderDirectionsMap[symbol])
                {
                    matrix[3 * row + dRow, 3 * column + dColumn] = true;
                }
            }
        }

        var ans = 0;

        var visited = new bool[m, m];
        var directions = new (int dRow, int dColumn)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < m; column++)
            {
                if (visited[row, column])
                {
                    continue;
                }

                if (matrix[row, column])
                {
                    continue;
                }

                ans++;
                var queue = new Queue<(int row, int column)>();
                queue.Enqueue((row, column));

                while (queue.Count > 0)
                {
                    var (currentRow, currentColumn) = queue.Dequeue();
                    if (visited[currentRow, currentColumn])
                    {
                        continue;
                    }

                    visited[currentRow, currentColumn] = true;

                    foreach (var (dRow, dColumn) in directions)
                    {
                        var nextRow = currentRow + dRow;
                        var nextColumn = currentColumn + dColumn;
                        if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= m || visited[nextRow, nextColumn] || matrix[nextRow, nextColumn])
                        {
                            continue;
                        }
                        queue.Enqueue((nextRow, nextColumn));
                    }
                }
            }
        }

        return ans;
    }
}
