namespace LeetCode.Problems._1970_Last_Day_Where_You_Can_Still_Cross;

/// <summary>
/// https://leetcode.com/submissions/detail/915454755/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LatestDayToCross(int row, int col, int[][] cells)
    {
        var low = 1;
        var high = cells.Length;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanCross(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool CanCross(int day)
        {
            var seen = new HashSet<(int r, int c)>();

            for (var i = 0; i < day; i++)
            {
                seen.Add((cells[i][0], cells[i][1]));
            }

            var queue = new Queue<(int r, int c)>();

            for (var c = 1; c <= col; c++)
            {
                if (seen.Add((1, c)))
                {
                    queue.Enqueue((1, c));
                }
            }

            while (queue.Count > 0)
            {
                var (r, c) = queue.Dequeue();

                if (r == row)
                {
                    return true;
                }

                foreach (var (dr, dc) in directions)
                {
                    var nextR = r + dr;
                    var nextC = c + dc;

                    if (nextR < 1 || nextC < 1 || nextR > row || nextC > col)
                    {
                        continue;
                    }

                    if (!seen.Add((nextR, nextC)))
                    {
                        continue;
                    }

                    queue.Enqueue((nextR, nextC));
                }
            }

            return false;
        }
    }
}
