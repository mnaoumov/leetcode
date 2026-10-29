namespace LeetCode.Problems._0885_Spiral_Matrix_III;

/// <summary>
/// https://leetcode.com/submissions/detail/1349314226/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] SpiralMatrixIII(int rows, int cols, int rStart, int cStart)
    {
        var cell = new Cell(rStart, cStart);
        var cells = new List<Cell> { cell };

        var direction = new Cell(0, 1);
        var cycleLength = 1;

        while (cells.Count < rows * cols)
        {
            for (var j = 0; j < 2; j++)
            {
                for (var i = 0; i < cycleLength; i++)
                {
                    cell += direction;

                    if (IsValid(cell))
                    {
                        cells.Add(cell);
                    }
                }

                direction = new Cell(direction.Col, -direction.Row);
            }

            cycleLength++;
        }

        return cells.Select(c => c.ToArray()).ToArray();

        bool IsValid(Cell cell1) => 0 <= cell1.Row && cell1.Row < rows && 0 <= cell1.Col && cell1.Col < cols;
    }

    private record Cell(int Row, int Col)
    {
        public int[] ToArray() => new[] { Row, Col };
        public static Cell operator +(Cell a, Cell b) => new(a.Row + b.Row, a.Col + b.Col);
    }
}
