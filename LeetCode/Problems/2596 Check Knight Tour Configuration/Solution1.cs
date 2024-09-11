namespace LeetCode.Problems._2596_Check_Knight_Tour_Configuration;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-337/submissions/detail/917866835/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CheckValidGrid(int[][] grid)
    {
        if (grid[0][0] != 0)
        {
            return false;
        }

        var moves = new[] { (2, 1), (2, -1), (-2, 1), (-2, -1), (1, 2), (1, -2), (-1, 2), (-1, -2) };
        var n = grid.Length;
        var row = 0;
        var column = 0;

        for (var i = 1; i < n * n; i++)
        {
            var isValid = false;

            foreach (var (dRow, dColumn) in moves)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (nextRow < 0 || nextColumn < 0 || nextRow >= n || nextColumn >= n)
                {
                    continue;
                }

                if (grid[nextRow][nextColumn] != i)
                {
                    continue;
                }

                isValid = true;
                row = nextRow;
                column = nextColumn;
                break;
            }

            if (!isValid)
            {
                return false;
            }
        }

        return true;
    }
}
