namespace LeetCode.Problems._2257_Count_Unguarded_Cells_in_the_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1458719564/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var directions = new (int dRow, int dCol)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        var cellTypes = new CellType[m, n];
        var queue = new Queue<(int row, int col, int dRow, int dCol)>();

        var ans = m * n;

        foreach (var guard in guards)
        {
            var row = guard[0];
            var col = guard[1];
            cellTypes[row, col] = CellType.Guard;
            ans--;

            foreach (var (dRow, dCol) in directions)
            {
                queue.Enqueue((row, col, dRow, dCol));
            }
        }

        foreach (var wall in walls)
        {
            var row = wall[0];
            var col = wall[1];
            cellTypes[row, col] = CellType.Wall;
            ans--;
        }

        while (queue.Count > 0)
        {
            var (row, col, dRow, dCol) = queue.Dequeue();
            var nextRow = row + dRow;
            var nextCol = col + dCol;

            if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n)
            {
                continue;
            }

            var cellType = cellTypes[nextRow, nextCol];

            switch (cellType)
            {
                case CellType.Wall or CellType.Guard:
                    continue;
                case CellType.Unguarded:
                    cellTypes[nextRow, nextCol] = CellType.Guarded;
                    ans--;
                    break;
            }

            queue.Enqueue((nextRow, nextCol, dRow, dCol));
        }

        return ans;
    }

    private enum CellType
    {
        Unguarded,
        Guarded,
        Guard,
        Wall
    }
}
