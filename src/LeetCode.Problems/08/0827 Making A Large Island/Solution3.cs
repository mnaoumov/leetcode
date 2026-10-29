namespace LeetCode.Problems._0827_Making_A_Large_Island;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LargestIsland(int[][] grid)
    {
        var n = grid.Length;
        var islandCornerCells = new Dictionary<Cell, Cell>();
        var islandSizes = new Dictionary<Cell, int>();

        var directions = new[]
        {
            new Cell(1, 0),
            new Cell(-1, 0),
            new Cell(0, 1),
            new Cell(0, -1)
        };

        const int land = 1;
        var ans = 1;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var cornerCell = new Cell(i, j);

                if (islandCornerCells.ContainsKey(cornerCell))
                {
                    continue;
                }

                if (grid[i][j] != land)
                {
                    continue;
                }

                var queue = new Queue<Cell>();
                queue.Enqueue(cornerCell);
                islandSizes[cornerCell] = 0;

                while (queue.Count > 0)
                {
                    var cell = queue.Dequeue();

                    if (!cell.IsValid(n))
                    {
                        continue;
                    }

                    if (grid[cell.Row][cell.Column] != land)
                    {
                        continue;
                    }

                    if (!islandCornerCells.TryAdd(cell, cornerCell))
                    {
                        continue;
                    }

                    islandSizes[cornerCell]++;
                    ans = Math.Max(ans, islandSizes[cornerCell]);

                    foreach (var direction in directions)
                    {
                        queue.Enqueue(cell.MoveTo(direction));
                    }
                }
            }
        }

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == land)
                {
                    continue;
                }

                var cell = new Cell(i, j);
                var neighborIslandCornerCells = new HashSet<Cell>();

                foreach (var direction in directions)
                {
                    var neighbor = cell.MoveTo(direction);

                    if (!neighbor.IsValid(n))
                    {
                        continue;
                    }

                    if (grid[neighbor.Row][neighbor.Column] != land)
                    {
                        continue;
                    }

                    neighborIslandCornerCells.Add(islandCornerCells[neighbor]);
                }

                ans = Math.Max(ans, 1 + neighborIslandCornerCells.Sum(neighbor => islandSizes[neighbor]));
            }
        }

        return ans;
    }

    private record Cell(int Row, int Column)
    {
        public bool IsValid(int n) => 0 <= Row && Row < n && 0 <= Column && Column < n;
        public Cell MoveTo(Cell direction) => new(Row + direction.Row, Column + direction.Column);
    }
}
