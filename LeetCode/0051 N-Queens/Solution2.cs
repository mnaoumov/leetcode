using JetBrains.Annotations;

namespace LeetCode._0051_N_Queens;

/// <summary>
/// https://leetcode.com/submissions/detail/829026814/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public IList<IList<string>> SolveNQueens(int n)
    {
        var board = new Board(n);

        var solvedBoards = Solve(board, 0);
        return solvedBoards.Select(b => b.ToStrings()).ToArray();
    }

    private static IEnumerable<Board> Solve(Board board, int rowId)
    {
        if (rowId >= board.Size)
        {
            yield return board;
            yield break;
        }

        var row = board.GetRow(rowId);

        for (var columnId = 0; columnId < row.Count; columnId++)
        {
            if (row[columnId] != Cell.Unknown)
            {
                continue;
            }

            var boardCopy = board.Clone();
            boardCopy.PutQueen(rowId, columnId);

            foreach (var solvedBoards in Solve(boardCopy, rowId + 1))
            {
                yield return solvedBoards;
            }
        }
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

        public IList<string> ToStrings()
        {
            var result = new List<string>();

            for (var rowId = 0; rowId < Size; rowId++)
            {
                result.Add(string.Join("", GetRow(rowId).Select(ToChar)));
            }

            return result;
        }

        private static char ToChar(Cell cell)
        {
            return cell switch
            {
                Cell.Queen => 'Q',
                Cell.Empty => '.',
                Cell.Unknown => throw new ArgumentOutOfRangeException(nameof(cell), cell, null),
                _ => throw new ArgumentOutOfRangeException(nameof(cell), cell, null)
            };
        }

        public IList<Cell> GetRow(int rowId)
        {
            var result = new List<Cell>();

            for (var columnId = 0; columnId < Size; columnId++)
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
                    copy.Cells[rowId, columnId] = Cells[rowId,columnId];
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