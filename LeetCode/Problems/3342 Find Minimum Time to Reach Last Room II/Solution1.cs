namespace LeetCode.Problems._3342_Find_Minimum_Time_to_Reach_Last_Room_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-422/submissions/detail/1441345299/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinTimeToReach(int[][] moveTime)
    {
        var m = moveTime.Length;
        var n = moveTime[0].Length;
        var minTimes = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                minTimes[i, j] = int.MaxValue;
            }
        }

        minTimes[0, 0] = 0;

        var queue = new PriorityQueue<(int row, int column, int time, int moveTimeCost), int>();
        queue.Enqueue((0, 0, 0, 1), 0);

        while (queue.Count > 0)
        {
            var (row, column, time, moveTimeCost) = queue.Dequeue();

            if (row == m - 1 && column == n - 1)
            {
                return time;
            }

            if (time > minTimes[row, column])
            {
                continue;
            }

            minTimes[row, column] = time;

            foreach (var (nextRow, nextColumn) in new[]
                     {
                         (row - 1, column),
                         (row + 1, column),
                         (row, column - 1),
                         (row, column + 1)
                     })
            {
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                var nextTime = Math.Max(time, moveTime[nextRow][nextColumn]) + moveTimeCost;

                if (nextTime >= minTimes[nextRow, nextColumn])
                {
                    continue;
                }

                minTimes[nextRow, nextColumn] = nextTime;
                var nextMoveTimeCost = moveTimeCost == 1 ? 2 : 1;
                queue.Enqueue((nextRow, nextColumn, nextTime, nextMoveTimeCost), nextTime);
            }
        }

        throw new InvalidOperationException();
    }
}
