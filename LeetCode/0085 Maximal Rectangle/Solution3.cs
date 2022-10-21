using JetBrains.Annotations;

namespace LeetCode._0085_Maximal_Rectangle;

/// <summary>
/// https://leetcode.com/submissions/detail/827390761/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
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

                var rowLength = int.MaxValue;

                for (var i = 1; i <= cell.OnesLengthToTheBottom; i++)
                {
                    rowLength = Math.Min(rowLength, cells[row + i - 1, column].OnesLengthToTheRight);
                    var area = i * rowLength;
                    result = Math.Max(result, area);
                }
            }
        }

        return result;
    }

    private class Cell
    {
        public bool IsOne { get; }
        public int OnesLengthToTheRight { get; set; }
        public int OnesLengthToTheBottom { get; set; }

        public Cell(char symbol = '0')
        {
            IsOne = symbol == '1';
        }
    }
}