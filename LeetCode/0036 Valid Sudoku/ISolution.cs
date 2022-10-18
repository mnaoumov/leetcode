using JetBrains.Annotations;

namespace LeetCode._0036_Valid_Sudoku;

[PublicAPI]
public interface ISolution
{
    public bool IsValidSudoku(char[][] board);
}