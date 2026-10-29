namespace LeetCode.Problems._0980_Unique_Paths_III;

/// <summary>
/// https://leetcode.com/submissions/detail/868362198/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int UniquePathsIII(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const int startingValue = 1;
        const int endingValue = 2;
        const int emptyValue = 0;
        const int obstacleValue = -1;

        var totalEmptySquaresCount = 0;
        (int row, int column) startingSquare = default;

        var visited = new bool[m, n];

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                switch (grid[row][column])
                {
                    case startingValue:
                        startingSquare = (row, column);
                        break;
                    case emptyValue:
                        totalEmptySquaresCount++;
                        break;
                    case obstacleValue:
                        visited[row, column] = true;
                        break;
                }
            }
        }

        var result = 0;

        var deltas = new (int dRow, int dColumn)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

        Backtrack(startingSquare.row, startingSquare.column, 0);

        return result;

        void Backtrack(int row, int column, int visitedEmptySquaresCount)
        {
            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                return;
            }

            if (visited[row, column])
            {
                return;
            }

            if (grid[row][column] == endingValue)
            {
                if (visitedEmptySquaresCount == totalEmptySquaresCount)
                {
                    result++;
                }

                return;
            }

            visited[row, column] = true;

            if (grid[row][column] == emptyValue)
            {
                visitedEmptySquaresCount++;
            }

            foreach (var (dRow, dColumn) in deltas)
            {
                Backtrack(row + dRow, column + dColumn, visitedEmptySquaresCount);
            }

            visited[row, column] = false;
        }
    }
}
