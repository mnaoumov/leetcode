namespace LeetCode.Problems._3905_Multi_Source_Flood_Fill;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-498/problems/multi-source-flood-fill/submissions/1982238494/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ColorGrid(int n, int m, int[][] sources)
    {
        var ans = Enumerable.Range(0, n).Select(_ => new int[m]).ToArray();

        var queue = new Queue<Cell>();

        foreach (var source in sources)
        {
            var r = source[0];
            var c = source[1];
            var color = source[2];
            queue.Enqueue(new Cell(r, c, color));
        }

        var directions = new (int dRow, int dColumn)[]
        {
            (1, 0),
            (-1, 0),
            (0, 1),
            (0, -1)
        };

        const int noColor = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var currentStepCells = new HashSet<Cell>();

            for (var i = 0; i < count; i++)
            {
                var cell = queue.Dequeue();

                var uncoloredCell = cell with { Color = noColor };

                if (ans[cell.Row][cell.Column] != noColor && !currentStepCells.Contains(uncoloredCell))
                {
                    continue;
                }

                if (cell.Color <= ans[cell.Row][cell.Column])
                {
                    continue;
                }

                ans[cell.Row][cell.Column] = cell.Color;
                currentStepCells.Add(uncoloredCell);

                foreach (var (dRow, dColumn) in directions)
                {
                    var nextRow = cell.Row + dRow;
                    var nextColumn = cell.Column + dColumn;

                    if (0 <= nextRow && nextRow < n && 0 <= nextColumn && nextColumn < m)
                    {
                        queue.Enqueue(new Cell(nextRow, nextColumn, cell.Color));
                    }
                }
            }
        }

        return ans;
    }

    private sealed record Cell(int Row, int Column, int Color);
}
