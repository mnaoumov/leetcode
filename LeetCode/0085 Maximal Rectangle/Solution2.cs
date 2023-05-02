using JetBrains.Annotations;

namespace LeetCode._0085_Maximal_Rectangle;

/// <summary>
/// https://leetcode.com/submissions/detail/827356461/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MaximalRectangle(char[][] matrix)
    {
        var rows = matrix.Length;
        var columns = matrix[0].Length;

        var cells = new Cell[rows + 1, columns + 1];

        for (var row = 0; row < rows; row++)
        {
            for (var column = 0; column < columns; column++)
            {
                cells[row, column] = new Cell(matrix[row][column]);
            }

            cells[row, columns] = new Cell();
        }

        for (var column = 0; column < columns + 1; column++)
        {
            cells[rows, column] = new Cell();
        }

        var result = 0;

        for (var row = rows - 1; row >= 0; row--)
        {
            for (var column = columns - 1; column >= 0; column--)
            {
                var cell = cells[row, column];
                if (!cell.IsOne)
                {
                    continue;
                }

                cell.OnesLengthToTheRight = cells[row, column + 1].OnesLengthToTheRight + 1;
                cell.OnesLengthToTheBottom = cells[row + 1, column].OnesLengthToTheBottom + 1;
                cell.OnesLengthToTheRightRectangle = Math.Min(cell.OnesLengthToTheRight,
                    cells[row + 1, column + 1].OnesLengthToTheRightRectangle + 1);
                cell.OnesLengthToTheBottomRectangle = Math.Min(cell.OnesLengthToTheBottom,
                    cells[row + 1, column + 1].OnesLengthToTheBottomRectangle + 1);

                var area = cell.OnesLengthToTheRightRectangle * cell.OnesLengthToTheBottomRectangle;

                if (area < cell.OnesLengthToTheRight)
                {
                    cell.OnesLengthToTheRightRectangle = cell.OnesLengthToTheRight;
                    cell.OnesLengthToTheBottomRectangle = 1;
                    area = cell.OnesLengthToTheRight;
                }

                if (area < cell.OnesLengthToTheBottom)
                {
                    cell.OnesLengthToTheRightRectangle = 1;
                    cell.OnesLengthToTheBottomRectangle = cell.OnesLengthToTheBottom;
                    area = cell.OnesLengthToTheBottom;
                }

                result = new[]
                {
                    result,
                    cell.OnesLengthToTheRight,
                    cell.OnesLengthToTheBottom,
                    area
                }.Max();
            }
        }

        return result;
    }

    private class Cell
    {
        public bool IsOne { get; }
        public int OnesLengthToTheRight { get; set; }
        public int OnesLengthToTheBottom { get; set; }
        public int OnesLengthToTheRightRectangle { get; set; }
        public int OnesLengthToTheBottomRectangle { get; set; }

        public Cell(char symbol = '0')
        {
            IsOne = symbol == '1';
        }
    }
}
