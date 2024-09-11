using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0348_Design_Tic_Tac_Toe;

/// <summary>
/// https://leetcode.com/submissions/detail/959326909/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ITicTacToe Create(int n) => new TicTacToe(n);

    private class TicTacToe : ITicTacToe
    {
        private readonly int _n;
        private readonly int[][] _rowCounts;
        private readonly int[][] _columnCounts;
        private readonly int[] _diagonalCounts;
        private readonly int[] _antiDiagonalCounts;

        public TicTacToe(int n)
        {
            _n = n;
            _rowCounts = Enumerable.Range(0, 2).Select(_ => new int[n]).ToArray();
            _columnCounts = Enumerable.Range(0, 2).Select(_ => new int[n]).ToArray();
            _diagonalCounts = new int[2];
            _antiDiagonalCounts = new int[2];
        }
    
        public int Move(int row, int col, int player)
        {
            var isWin = false;
            isWin |= IncrementAndCheckForWin(ref _rowCounts[player - 1][row]);
            isWin |= IncrementAndCheckForWin(ref _columnCounts[player - 1][col]);
            
            if (row == col)
            {
                isWin |= IncrementAndCheckForWin(ref _diagonalCounts[player - 1]);
            }

            if (row + col == _n)
            {
                isWin |= IncrementAndCheckForWin(ref _antiDiagonalCounts[player - 1]);
            }

            return isWin ? player : 0;
        }

        private bool IncrementAndCheckForWin(ref int value)
        {
            value++;
            return value == _n;
        }
    }
}
