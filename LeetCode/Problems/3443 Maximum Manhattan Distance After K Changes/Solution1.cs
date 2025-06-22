namespace LeetCode.Problems._3443_Maximum_Manhattan_Distance_After_K_Changes;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-435/problems/maximum-manhattan-distance-after-k-changes/submissions/1528124847/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
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

        var queue = new Queue<(Cell cell, int changesLeft, int letterIndex)>();
        var ans = 0;
        queue.Enqueue((new Cell(0, 0), k, 0));

        while (queue.Count > 0)
        {
            var (cell, changesLeft, letterIndex) = queue.Dequeue();

            ans = Math.Max(ans, Math.Abs(cell.Row) + Math.Abs(cell.Column));

            if (letterIndex == s.Length)
            {
                continue;
            }

            var direction = directions[s[letterIndex]];
            queue.Enqueue((new Cell(cell.Row + direction.Row, cell.Column + direction.Column), changesLeft, letterIndex + 1));

            if (changesLeft > 0)
            {
                queue.Enqueue((new Cell(cell.Row - direction.Row, cell.Column - direction.Column), changesLeft - 1,
                    letterIndex + 1));
            }
        }

        return ans;
    }

    private record Cell(int Row, int Column);
}
