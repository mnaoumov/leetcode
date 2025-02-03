namespace LeetCode.Problems._0407_Trapping_Rain_Water_II;

/// <summary>
/// https://leetcode.com/problems/trapping-rain-water-ii/submissions/1514057256/?envType=daily-question&envId=2025-01-20
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TrapRainWater(int[][] heightMap)
    {
        var m = heightMap.Length;
        var n = heightMap[0].Length;

        var pq = new PriorityQueue<Cell, int>();

        for (var row = 0; row < m; row++)
        {
            InitBorderCell(row, 0);
            InitBorderCell(row, n - 1);
        }

        for (var column = 1; column < n - 1; column++)
        {
            InitBorderCell(0, column);
            InitBorderCell(m - 1, column);
        }

        var directions = new[]
        {
            new Cell(0, 1, 0),
            new Cell(0, -1, 0),
            new Cell(1, 0, 0),
            new Cell(-1, 0, 0)
        };

        var visited = new bool[m, n];
        var ans = 0;

        while (pq.Count > 0)
        {
            var cell = pq.Dequeue();

            if (visited[cell.Row, cell.Column])
            {
                continue;
            }

            visited[cell.Row, cell.Column] = true;
            ans += cell.Height - heightMap[cell.Row][cell.Column];

            foreach (var direction in directions)
            {
                var nextCell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column, 0);
                if (nextCell.Row < 0 || nextCell.Row >= m || nextCell.Column < 0 || nextCell.Column >= n)
                {
                    continue;
                }

                nextCell = nextCell with
                {
                    Height = Math.Max(cell.Height, heightMap[nextCell.Row][nextCell.Column])
                };
                pq.Enqueue(nextCell, nextCell.Height);
            }
        }

        return ans;

        void InitBorderCell(int row, int column)
        {
            var cell = new Cell(row, column, heightMap[row][column]);
            pq.Enqueue(cell, cell.Height);
        }
    }

    private record Cell(int Row, int Column, int Height);
}