// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedVariable
// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global
#pragma warning disable IDE0051

namespace LeetCode.Templates;

public static class GridTemplate
{
    // Grid BFS: the distance from the top-left cell to every reachable cell, -1 when unreachable.
    private static int[][] Sample(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var distances = Enumerable.Range(0, m).Select(_ => Enumerable.Repeat(-1, n).ToArray()).ToArray();

        var start = new Cell(0, 0);
        distances[start.Row][start.Column] = 0;
        var queue = new Queue<Cell>();
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            var cell = queue.Dequeue();

            foreach (var neighbour in cell.Neighbours(m, n))
            {
                if (grid[neighbour.Row][neighbour.Column] == 1 || distances[neighbour.Row][neighbour.Column] != -1)
                {
                    continue;
                }

                distances[neighbour.Row][neighbour.Column] = distances[cell.Row][cell.Column] + 1;
                queue.Enqueue(neighbour);
            }
        }

        return distances;
    }

    public readonly record struct Cell(int Row, int Column)
    {
        // Right, down, left, up: clockwise, so turning right is (index + 1) % 4.
        public static readonly (int RowDelta, int ColumnDelta)[] Directions4 = [(0, 1), (1, 0), (0, -1), (-1, 0)];

        public static readonly (int RowDelta, int ColumnDelta)[] Directions8 =
            [(0, 1), (1, 1), (1, 0), (1, -1), (0, -1), (-1, -1), (-1, 0), (-1, 1)];

        public bool IsInside(int rowCount, int columnCount) =>
            Row >= 0 && Row < rowCount && Column >= 0 && Column < columnCount;

        public Cell Move((int RowDelta, int ColumnDelta) direction, int steps = 1) =>
            new(Row + direction.RowDelta * steps, Column + direction.ColumnDelta * steps);

        public IEnumerable<Cell> Neighbours(int rowCount, int columnCount, bool includeDiagonals = false)
        {
            foreach (var direction in includeDiagonals ? Directions8 : Directions4)
            {
                var neighbour = Move(direction);

                if (neighbour.IsInside(rowCount, columnCount))
                {
                    yield return neighbour;
                }
            }
        }

        public int ManhattanDistance(Cell other) => Math.Abs(Row - other.Row) + Math.Abs(Column - other.Column);

        public T GetValue<T>(T[][] grid) => grid[Row][Column];
    }
}
