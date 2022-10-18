using JetBrains.Annotations;

namespace LeetCode._0037_Sudoku_Solver;

[PublicAPI]
public interface ISolution
{
    public void SolveSudoku(char[][] board);
}