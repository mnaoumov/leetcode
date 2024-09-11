namespace LeetCode.Problems._3242_Design_Neighbor_Sum_Service;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-409/submissions/detail/1343694590/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IneighborSum Create(int[][] grid) => new neighborSum(grid);

    // ReSharper disable once InconsistentNaming
    private class neighborSum : IneighborSum
    {
        private readonly int[][] _grid;
        private readonly (int row, int column)[] _valueToCoordinates;
        private readonly (int dRow, int dColumn)[] _adjacentDirections =
        {
            (-1, 0),
            (1, 0),
            (0, -1),
            (0, 1)
        };

        private readonly (int dRow, int dColumn)[] _diagonalDirections =
        {
            (-1, -1),
            (-1, 1),
            (1, -1),
            (1, 1)
        };


        public neighborSum(int[][] grid)
        {
            _grid = grid;
            var n = grid.Length;

            _valueToCoordinates = new (int row, int column)[n * n];

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    var value = grid[row][column];
                    _valueToCoordinates[value] = (row, column);
                }
            }
        }
    
        public int AdjacentSum(int value) => Sum(value, _adjacentDirections);

        public int DiagonalSum(int value) => Sum(value, _diagonalDirections);

        private int Sum(int value, (int dRow, int dColumn)[] directions)
        {
            var (row, column) = _valueToCoordinates[value];
            var sum = 0;

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                sum += GetValue(nextRow, nextColumn);
            }

            return sum;
        }

        private int GetValue(int row, int column) =>
            IsValidCoordinate(row) && IsValidCoordinate(column) ? _grid[row][column] : 0;

        private bool IsValidCoordinate(int coordinate) => coordinate >= 0 && coordinate < _grid.Length;
    }
}
