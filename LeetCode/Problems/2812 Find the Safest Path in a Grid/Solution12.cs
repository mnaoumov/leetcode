using JetBrains.Annotations;

namespace LeetCode.Problems._2812_Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1259329153/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution12 : ISolution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        var n = grid.Count;
        const int thief = 1;

        if (grid[0][0] == thief || grid[n - 1][n - 1] == thief)
        {
            return 0;
        }

        var deltas = new[]
        {
            (1, 0), (-1, 0), (0, 1), (0, -1)
        };

        var cellSafenessFactors = new int[n, n];
        InitCellSafenessFactors();

        var pq = new PriorityQueue<(int row, int column, int factor), int>();
        pq.Enqueue((0, 0, cellSafenessFactors[0, 0]), -cellSafenessFactors[0, 0]);

        var visited = new bool[n, n];

        while (pq.Count > 0)
        {
            var (row, column, factor) = pq.Dequeue();

            if (row == n - 1 && row == n - 1)
            {
                return factor;
            }

            visited[row, column] = true;

            foreach (var (dRow, dColumn) in deltas)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (nextRow < 0 || nextRow >= n || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                if (visited[nextRow, nextColumn])
                {
                    continue;
                }

                var nextFactor = Math.Min(factor, cellSafenessFactors[nextRow, nextColumn]);
                pq.Enqueue((nextRow, nextColumn, nextFactor), -nextFactor);
            }
        }

        throw new InvalidOperationException();

        void InitCellSafenessFactors()
        {
            var queue = new Queue<(int row, int column)>();

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    if (grid[row][column] == thief)
                    {
                        queue.Enqueue((row, column));
                    }
                }
            }

            const int unset = -1;

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    cellSafenessFactors[row, column] = unset;
                }
            }

            var safenessFactor = 0;

            while (queue.Count > 0)
            {
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (row, column) = queue.Dequeue();

                    if (row < 0 || row >= n || column < 0 || column >= n)
                    {
                        continue;
                    }

                    if (cellSafenessFactors[row, column] != unset)
                    {
                        continue;
                    }

                    cellSafenessFactors[row, column] = safenessFactor;

                    foreach (var (dRow, dColumn) in deltas)
                    {
                        queue.Enqueue((row + dRow, column + dColumn));
                    }
                }

                safenessFactor++;
            }
        }
    }
}
