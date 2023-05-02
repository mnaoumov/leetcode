using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0036_Valid_Sudoku;

/// <summary>
/// https://leetcode.com/submissions/detail/813043052/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsValidSudoku(char[][] board)
    {
        for (int i = 0; i < 9; i++)
        {
            var row = GetRow(i);
            var column = GetColumn(i);
            var square = GetSquare(i);

            if (new[] { row, column, square }.Any(@group => !IsValid(group)))
            {
                return false;
            }
        }

        return true;

        char[] GetRow(int id)
        {
            return board[id];
        }

        char[] GetColumn(int id)
        {
            return board.Select(row => row[id]).ToArray();
        }

        char[] GetSquare(int id)
        {
            var squareRowId = id / 3;
            var squareColumnId = id % 3;

            return board.Skip(3 * squareRowId).Take(3).SelectMany(row => row.Skip(3 * squareColumnId).Take(3)).ToArray();
        }

        bool IsValid(char[] @group)
        {
            var set = new HashSet<char>();
            return group.Where(x => x != '.').All(digit => set.Add(digit));
        }
    }
}
