namespace LeetCode.Problems._2577_Minimum_Time_to_Visit_a_Cell_In_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-334/submissions/detail/905079188/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumTime(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        if (grid[0][1] > 1 && grid[1][0] > 1)
        {
            return -1;
        }

        var queue = new Queue<(int row, int column)>();
        queue.Enqueue((0, 0));

        var deltas = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var seen = new HashSet<(int row, int column)>();

        var skippedCellsQueue = new PriorityQueue<(int row, int column), int>();

        var time = 0;

        while (queue.Count > 0 || skippedCellsQueue.Count > 0)
        {
            while (skippedCellsQueue.TryPeek(out var element, out var skippedTime) && skippedTime == time)
            {
                queue.Enqueue(element);
                skippedCellsQueue.Dequeue();
            }

            var count = queue.Count;

            if (count == 0)
            {
                skippedCellsQueue.TryPeek(out _, out var skippedTime);
                time = skippedTime;
                continue;
            }

            for (var i = 0; i < count; i++)
            {
                var (row, column) = queue.Dequeue();

                if (row < 0 || row >= m || column < 0 || column >= n)
                {
                    continue;
                }

                if (grid[row][column] > time)
                {
                    var nextTime = grid[row][column];
                    nextTime += (nextTime - time) % 2;
                    skippedCellsQueue.Enqueue((row, column), nextTime);
                    continue;
                }

                if (row == m - 1 && column == n - 1)
                {
                    return time;
                }

                if (!seen.Add((row, column)))
                {
                    continue;
                }

                foreach (var (dRow, dColumn) in deltas)
                {
                    queue.Enqueue((row + dRow, column + dColumn));
                }
            }

            time++;
        }

        return -1;
    }
}
