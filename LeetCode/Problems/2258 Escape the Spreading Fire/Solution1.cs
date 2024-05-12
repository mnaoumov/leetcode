using JetBrains.Annotations;

namespace LeetCode.Problems._2258_Escape_the_Spreading_Fire;

/// <summary>
/// https://leetcode.com/submissions/detail/915970374/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaximumMinutes(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var initialFireCells = new HashSet<(int row, int column)>();
        const int grass = 0;
        const int fire = 1;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == fire)
                {
                    initialFireCells.Add((i, j));
                }
            }
        }

        var low = 0;
        var high = m * n;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (CanReachSafehouse(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high == m * n ? 1_000_000_000 : high;

        bool CanReachSafehouse(int time)
        {
            var fireCells = initialFireCells.ToHashSet();
            var fireCellsQueue = new Queue<(int row, int column)>(fireCells);

            for (var i = 0; i < time; i++)
            {
                if (fireCellsQueue.Count == 0)
                {
                    break;
                }

                MoveFire();

                if (fireCells.Contains((0, 0)) || fireCells.Contains((m - 1, n - 1)))
                {
                    return false;
                }
            }

            var pathQueue = new Queue<(int row, int column)>();
            pathQueue.Enqueue((0, 0));
            var seen = new HashSet<(int row, int column)> { (0, 0) };

            while (pathQueue.Count > 0)
            {
                var count = pathQueue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (row, column) = pathQueue.Dequeue();

                    if ((row, column) == (m - 1, n - 1))
                    {
                        return true;
                    }

                    if (fireCells.Contains((row, column)))
                    {
                        continue;
                    }

                    foreach (var (dRow, dColumn) in directions)
                    {
                        var nextRow = row + dRow;
                        var nextColumn = column + dColumn;

                        if (nextRow < 0 || nextColumn < 0 || nextRow >= m || nextColumn >= n)
                        {
                            continue;
                        }

                        if (grid[nextRow][nextColumn] != grass)
                        {
                            continue;
                        }

                        var nextCell = (nextRow, nextColumn);

                        if (fireCells.Contains(nextCell))
                        {
                            continue;
                        }

                        if (!seen.Add(nextCell))
                        {
                            continue;
                        }

                        pathQueue.Enqueue(nextCell);
                    }
                }

                MoveFire();

                if (fireCells.Contains((m - 1, n - 1)))
                {
                    return false;
                }
            }

            return false;

            void MoveFire()
            {
                var count = fireCellsQueue.Count;

                for (var j = 0; j < count; j++)
                {
                    var (row, column) = fireCellsQueue.Dequeue();

                    foreach (var (dRow, dColumn) in directions)
                    {
                        var nextRow = row + dRow;
                        var nextColumn = column + dColumn;

                        if (nextRow < 0 || nextColumn < 0 || nextRow >= m || nextColumn >= n)
                        {
                            continue;
                        }

                        if (grid[nextRow][nextColumn] != grass)
                        {
                            continue;
                        }

                        var nextCell = (nextRow, nextColumn);

                        if (!fireCells.Add(nextCell))
                        {
                            continue;
                        }

                        fireCellsQueue.Enqueue(nextCell);
                    }
                }
            }
        }
    }
}
