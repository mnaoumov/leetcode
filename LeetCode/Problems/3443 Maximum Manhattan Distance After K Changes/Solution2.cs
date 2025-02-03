namespace LeetCode.Problems._3443_Maximum_Manhattan_Distance_After_K_Changes;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int MaxDistance(string s, int k)
    {
        const char north = 'N';
        const char south = 'S';
        const char east = 'E';
        const char west = 'W';

        var directions = new Dictionary<char, Cell>
        {
            [north] = new Cell(-1, 0),
            [south] = new Cell(1, 0),
            [east] = new Cell(0, 1),
            [west] = new Cell(0, -1)
        };

        var ans = 0;
        var counts = new Dictionary<char, int>();
        foreach (var letter in new[] { north, south, east, west })
        {
            counts[letter] = 0;
        }

        var cell = new Cell(0, 0);
        var maxAbsRow = 0;
        var maxAbsColumn = 0;
        var rowChangesCount = 0;
        var columnChangesCount = 0;

        foreach (var letter in s)
        {
            var direction = directions[letter];
            cell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column);
            ans = Math.Max(ans, Math.Abs(cell.Row) + Math.Abs(cell.Column));

            switch (letter)
            {
                case north:
                    if (cell.Row > 0)
                    {
                        continue;
                    }
                    break;
                case south:
                    if (cell.Row < 0)
                    {
                        continue;
                    }
                    break;
                case east:
                case west:
                    continue;
            }

            var oppositeLetter = OppositeLetter(letter);
            var possibleChangesCount = Math.Min(k, counts[oppositeLetter]);
            var possibleCell = new Cell(cell.Row - direction.Row * 2 * possibleChangesCount, cell.Column - direction.Column * 2 * possibleChangesCount);
            maxAbsRow = Math.Max(maxAbsRow, Math.Abs(possibleCell.Row));
            maxAbsColumn = Math.Max(maxAbsColumn, Math.Abs(possibleCell.Column));
            rowChangesCount = Math.Max(rowChangesCount, possibleChangesCount);
            counts[letter]++;
        }

        k -= rowChangesCount;

        foreach (var letter in s)
        {
            var direction = directions[letter];
            cell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column);
            ans = Math.Max(ans, Math.Abs(cell.Row) + Math.Abs(cell.Column));

            switch (letter)
            {
                case north:
                case south:
                    continue;
                case east:
                    if (cell.Column < 0)
                    {
                        continue;
                    }
                    break;
                case west:
                    if (cell.Column > 0)
                    {
                        continue;
                    }
                    break;
            }

            var oppositeLetter = OppositeLetter(letter);
            var possibleChangesCount = Math.Min(k, counts[oppositeLetter]);
            var possibleCell = new Cell(cell.Row - direction.Row * 2 * possibleChangesCount, cell.Column - direction.Column * 2 * possibleChangesCount);
            maxAbsRow = Math.Max(maxAbsRow, Math.Abs(possibleCell.Row));
            maxAbsColumn = Math.Max(maxAbsColumn, Math.Abs(possibleCell.Column));
            rowChangesCount = Math.Max(rowChangesCount, possibleChangesCount);
            counts[letter]++;
        }



        return ans;

        char OppositeLetter(char letter) => letter switch
        {
            north => south,
            south => north,
            east => west,
            west => east,
            _ => throw new ArgumentOutOfRangeException(nameof(letter), letter, null)
        };
    }

    private record Cell(int Row, int Column);
}
