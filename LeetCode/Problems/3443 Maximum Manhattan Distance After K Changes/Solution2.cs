namespace LeetCode.Problems._3443_Maximum_Manhattan_Distance_After_K_Changes;

/// <summary>
/// https://leetcode.com/problems/maximum-manhattan-distance-after-k-changes/submissions/1669963374/
/// </summary>
[UsedImplicitly]
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
            [north] = new(-1, 0),
            [south] = new(1, 0),
            [east] = new(0, 1),
            [west] = new(0, -1)
        };

        var ans = 0;

        foreach (var verticalDirectionLetter in new[] { north, south })
        {
            foreach (var horizontalDirectionLetter in new[] { east, west })
            {
                var changesLeft = k;
                var cell = new Cell(0, 0);

                foreach (var letter in s)
                {
                    var direction = directions[letter];

                    if (letter != verticalDirectionLetter && letter != horizontalDirectionLetter && changesLeft > 0)
                    {
                        direction = new Cell(-direction.Row, -direction.Column);
                        changesLeft--;
                    }

                    cell = new Cell(cell.Row + direction.Row, cell.Column + direction.Column);
                    ans = Math.Max(ans, cell.ManhattanDistance);
                }
            }
        }

        return ans;
    }

    private record Cell(int Row, int Column)
    {
        public int ManhattanDistance => Math.Abs(Row) + Math.Abs(Column);
    }
}
