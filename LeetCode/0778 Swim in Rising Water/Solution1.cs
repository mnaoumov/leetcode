using JetBrains.Annotations;

namespace LeetCode._0778_Swim_in_Rising_Water;

/// <summary>
/// https://leetcode.com/submissions/detail/915446625/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SwimInWater(int[][] grid)
    {
        var n = grid.Length;
        var low = Math.Max(grid[0][0], grid[n - 1][n - 1]);
        var high = grid.SelectMany(x => x).Max();

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanSwim(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool CanSwim(int time)
        {
            var queue = new Queue<(int i, int j)>();
            var seen = new HashSet<(int i, int j)>();

            queue.Enqueue((0, 0));
            seen.Add((0, 0));
            var directions = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };

            while (queue.Count > 0)
            {
                var (i, j) = queue.Dequeue();

                if ((i, j) == (n - 1, n - 1))
                {
                    return true;
                }

                foreach (var (di, dj) in directions)
                {
                    var nextI = i + di;
                    var nextJ = j + dj;

                    if (nextI < 0 || nextJ < 0 || nextI >= n || nextJ >= n)
                    {
                        continue;
                    }

                    if (grid[nextI][nextJ] > time)
                    {
                        continue;
                    }

                    if (!seen.Add((nextI, nextJ)))
                    {
                        continue;
                    }

                    queue.Enqueue((nextI, nextJ));
                }
            }

            return false;
        }
    }
}
