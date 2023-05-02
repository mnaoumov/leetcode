using System.Text;
using Newtonsoft.Json;

using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0037_Sudoku_Solver;

/// <summary>
/// https://leetcode.com/submissions/detail/813133781/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public void SolveSudoku(char[][] board)
    {
        var boardObj = new Board(board);
        boardObj.Solve();

        for (var rowId = 0; rowId < Board.Size; rowId++)
        {
            for (var columnId = 0; columnId < Board.Size; columnId++)
            {
                board[rowId][columnId] = boardObj.GetCell(rowId, columnId).Value;
            }
        }
    }

    private class Board
    {
        public const int Size = 9;
        private Group[] Rows { get; } = new Group[Size];
        private Group[] Columns { get; } = new Group[Size];
        private Group[] Squares { get; } = new Group[Size];
        private Cell[] Cells { get; } = new Cell[Size * Size];
        private IEnumerable<Cell> UnsolvedCells => Cells.Where(cell => !cell.IsSolved());

        public Board(char[][] rawBoard)
        {
            for (var i = 0; i < Size; i++)
            {
                Rows[i] = new Group { Id = i };
                Columns[i] = new Group { Id = i };
                Squares[i] = new Group { Id = i };
            }

            for (var rowId = 0; rowId < Size; rowId++)
            {
                for (var columnId = 0; columnId < Size; columnId++)
                {
                    var cellId = GetCellId(rowId, columnId);
                    var squareId = (rowId / 3) * 3 + (columnId / 3);

                    var cell = Cells[cellId] = new Cell
                    {
                        Row = Rows[rowId],
                        Column = Columns[columnId],
                        Square = Squares[squareId],
                        Value = rawBoard[rowId][columnId]
                    };

                    cell.Row.Cells.Add(cell);
                    cell.Column.Cells.Add(cell);
                    cell.Square.Cells.Add(cell);
                }
            }

            foreach (var cell in UnsolvedCells)
            {
                cell.CalculateCandidates();
            }
        }

        private static int GetCellId(int rowId, int columnId)
        {
            return rowId * Size + columnId;
        }

        public void Solve()
        {
            TrySolve();
        }

        private bool TrySolve()
        {
            if (!UnsolvedCells.Any())
            {
                return true;
            }

            if (UnsolvedCells.Any(cell => cell.Candidates.Length == 0))
            {
                return false;
            }

            var cell = UnsolvedCells.OrderBy(cell => cell.Candidates.Length).First();
            foreach (var cellCandidate in cell.Candidates.ToArray())
            {
                cell.SetCandidate(cellCandidate);

                if (TrySolve())
                {
                    return true;
                }

                cell.Reset();
            }

            return false;
        }

        public Cell GetCell(int rowId, int columnId)
        {
            var cellId = GetCellId(rowId, columnId);
            return Cells[cellId];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int rowId = 0; rowId < Size; rowId++)
            {
                for (int columnId = 0; columnId < Size; columnId++)
                {
                    var cell = GetCell(rowId, columnId);
                    sb.Append(cell.Value);
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }

    private class Cell
    {
        private const char UnsolvedValue = '.';

        public char Value { get; set; }

        public Group Row { get; init; } = null!;
        public Group Column { get; init; } = null!;
        public Group Square { get; init; } = null!;
        static readonly char[] AllDigits = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public char[] Candidates { get; private set; } = null!;

        public void CalculateCandidates()
        {
            if (IsSolved())
            {
                return;
            }

            var candidates = new HashSet<char>(AllDigits);
            candidates.ExceptWith(Row.Values);
            candidates.ExceptWith(Column.Values);
            candidates.ExceptWith(Square.Values);
            Candidates = candidates.OrderBy(x => x).ToArray();
        }

        public bool IsSolved() => Value != UnsolvedValue;

        public void Reset()
        {
            Value = UnsolvedValue;
            RecalculateNeighborsCandidates();
        }

        private void RecalculateNeighborsCandidates()
        {
            var neighbors = new HashSet<Cell>();
            neighbors.UnionWith(Row.Cells);
            neighbors.UnionWith(Column.Cells);
            neighbors.UnionWith(Square.Cells);
            neighbors.Remove(this);

            foreach (var cell in neighbors)
            {
                cell.CalculateCandidates();
            }
        }

        public void SetCandidate(char candidate)
        {
            Value = candidate;
            RecalculateNeighborsCandidates();
        }

        public override string ToString() => JsonConvert.SerializeObject(new
        {
            Value,
            Row = Row.Id,
            Column = Column.Id,
            Square = Square.Id
        });
    }

    private class Group
    {
        public int Id { get; init; }
        public List<Cell> Cells { get; } = new();
        public IEnumerable<char> Values => Cells.Select(cell => cell.Value);
    }
}
