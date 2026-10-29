namespace LeetCode.Problems._3619_Count_Islands_With_Total_Value_Divisible_by_K;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-161/problems/count-islands-with-total-value-divisible-by-k/submissions/1703625246/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CountIslands(int[][] grid, int k)
    {
        var m =  grid.Length;
        var n = grid[0].Length;

        var visited = new bool[m, n];
        var ans = 0;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                if (visited[row, col])
                {
                    continue;
                }

                if (grid[row][col] == 0)
                {
                    visited[row, col] = true;
                    continue;
                }

                var islandSum = 0L;
                var queue = new Queue<(int row, int col)>();
                queue.Enqueue((row, col));

                while (queue.Count > 0)
                {
                    var (row2, col2) = queue.Dequeue();

                    if (visited[row2, col2])
                    {
                        continue;
                    }

                    visited[row2, col2] = true;

                    islandSum += grid[row2][col2];

                    foreach (var (dRow, dColumn) in directions)
                    {
                        var nextRow = row + dRow;
                        var nextCol = col + dColumn;

                        if (nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n)
                        {
                            continue;
                        }

                        if (visited[nextRow, nextCol])
                        {
                            continue;
                        }

                        queue.Enqueue((nextRow, nextCol));
                    }
                }

                if (islandSum % k == 0)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
