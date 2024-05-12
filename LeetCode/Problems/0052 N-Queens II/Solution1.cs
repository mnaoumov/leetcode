using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0052_N_Queens_II;

/// <summary>
/// https://leetcode.com/submissions/detail/819088644/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TotalNQueens(int n)
    {
        var board = new Board(n);

        return Solve(board, 0);
    }

    private static int Solve(Board board, int rowId)
    {
        if (rowId >= board.Size)
        {
            return 1;
        }

        var row = board.GetRow(rowId);

        var result = 0;

        for (var columnId = 0; columnId < row.Count; columnId++)
        {
            if (row[columnId] == Cell.Unknown)
            {
                var boardCopy = board.Clone();
                boardCopy.PutQueen(rowId, columnId);

                result += Solve(boardCopy, rowId + 1);
            }
        }

        return result;
    }

    private class Board
    {
        private Cell[,] Cells { get; }
        public int Size { get; }

        public Board(int n)
        {
            Size = n;
            Cells = new Cell[n, n];
        }

        public IList<Cell> GetRow(int rowId)
        {
            var result = new List<Cell>();

            for (int columnId = 0; columnId < Size; columnId++)
            {
                result.Add(Cells[rowId, columnId]);
            }

            return result;
        }

        public Board Clone()
        {
            var copy = new Board(Size);

            for (var rowId = 0; rowId < Size; rowId++)
            {
                for (var columnId = 0; columnId < Size; columnId++)
                {
                    copy.Cells[rowId, columnId] = Cells[rowId, columnId];
                }
            }

            return copy;
        }

        public void PutQueen(int rowId, int columnId)
        {
            Cells[rowId, columnId] = Cell.Queen;
            for (var otherColumnId = 0; otherColumnId < Size; otherColumnId++)
            {
                Cells[rowId, otherColumnId] = Cell.Empty;
            }

            for (var otherRowId = 0; otherRowId < Size; otherRowId++)
            {
                Cells[otherRowId, columnId] = Cell.Empty;
            }

            var sum = rowId + columnId;
            var diff = rowId - columnId;

            for (var otherRowId = Math.Max(sum - Size + 1, 0); otherRowId <= Math.Min(sum, Size - 1); otherRowId++)
            {
                var otherColumnId = sum - otherRowId;
                Cells[otherRowId, otherColumnId] = Cell.Empty;
            }

            for (var otherRowId = Math.Max(diff, 0); otherRowId <= Math.Min(diff + Size - 1, Size - 1); otherRowId++)
            {
                var otherColumnId = otherRowId - diff;
                Cells[otherRowId, otherColumnId] = Cell.Empty;
            }

            Cells[rowId, columnId] = Cell.Queen;
        }
    }

    private enum Cell
    {
        Unknown,
        Queen,
        Empty
    }
}
