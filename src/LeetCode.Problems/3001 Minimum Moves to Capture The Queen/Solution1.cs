namespace LeetCode.Problems._3001_Minimum_Moves_to_Capture_The_Queen;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-379/submissions/detail/1139101812/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinMovesToCaptureTheQueen(int a, int b, int c, int d, int e, int f)
    {
        var whiteRookOriginalCell = new Cell(a, b);
        var whiteBishopInitialCell = new Cell(c, d);
        var blackQueenCell = new Cell(e, f);

        var queue = new Queue<(Cell whiteRookCell, Cell whiteBishopCell)>();
        queue.Enqueue((whiteRookOriginalCell, whiteBishopInitialCell));

        var ans = 0;

        var rookDeltas = new (int dRow, int dColumn)[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        var bishopDeltas = new (int dRow, int dColumn)[] { (1, 1), (-1, -1), (1, -1), (-1, 1) };
        const int maxPossibleMoves = 7;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (whiteRookCell, whiteBishopCell) = queue.Dequeue();

                if (whiteRookCell == blackQueenCell || whiteBishopCell == blackQueenCell)
                {
                    return ans;
                }

                foreach (var (dRow, dColumn) in rookDeltas)
                {
                    var newWhiteRookCell = whiteRookCell;

                    for (var j = 0; j < maxPossibleMoves; j++)
                    {
                        newWhiteRookCell = new Cell(newWhiteRookCell.Row + dRow, newWhiteRookCell.Column + dColumn);

                        if (!newWhiteRookCell.IsValid() || newWhiteRookCell == whiteBishopCell)
                        {
                            break;
                        }

                        queue.Enqueue((newWhiteRookCell, whiteBishopCell));
                    }
                }

                foreach (var (dRow, dColumn) in bishopDeltas)
                {
                    var newWhiteBishopCell = whiteBishopCell;

                    for (var j = 0; j < maxPossibleMoves; j++)
                    {
                        newWhiteBishopCell = new Cell(newWhiteBishopCell.Row + dRow, newWhiteBishopCell.Column + dColumn);

                        if (!newWhiteBishopCell.IsValid() || newWhiteBishopCell == whiteRookCell)
                        {
                            break;
                        }

                        queue.Enqueue((newWhiteBishopCell, whiteBishopCell));
                    }
                }
            }

            ans++;
        }

        throw new InvalidOperationException();
    }

    private record Cell(int Row, int Column)
    {
        public bool IsValid() => Row is >= 1 and <= 8 && Column is >= 1 and <= 8;
    }
}
