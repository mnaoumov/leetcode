namespace LeetCode.Problems._3609_Minimum_Moves_to_Reach_Target_in_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-457/problems/minimum-moves-to-reach-target-in-grid/submissions/1687904834/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinMoves(int sx, int sy, int tx, int ty)
    {
        if (sx == 0 && sy == 0)
        {
            return tx == 0 && ty == 0 ? 0 : -1;
        }

        var queue = new Queue<(int x, int y)>();
        queue.Enqueue((sx, sy));

        var ans = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;
            for (var i = 0; i < count; i++)
            {
                var (x, y) = queue.Dequeue();
                if (x == tx && y == ty)
                {
                    return ans;
                }
                if (x > tx || y > ty)
                {
                    continue;
                }

                var m = Math.Max(x, y);
                queue.Enqueue((x + m, y));
                queue.Enqueue((x, y + m));
            }

            ans++;
        }

        return -1;
    }
}
