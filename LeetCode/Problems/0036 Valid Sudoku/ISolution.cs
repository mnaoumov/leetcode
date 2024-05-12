using JetBrains.Annotations;

namespace LeetCode.Problems._0036_Valid_Sudoku;

[PublicAPI]
public interface ISolution
{
    public bool IsValidSudoku(char[][] board);
}
