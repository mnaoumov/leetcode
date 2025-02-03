namespace LeetCode.Problems._2852_Sum_of_Remoteness_of_All_Cells;

/// <summary>
/// https://leetcode.com/problems/sum-of-remoteness-of-all-cells/submissions/1517490713/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long SumRemoteness(int[][] grid)
    {
        var n = grid.Length;
        var visited = new bool[n, n];
        const int blocked = -1;
        var totalCount = 0;
        var totalSum = 0L;
        var ans = 0L;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (visited[i, j])
                {
                    continue;
                }

                var queue = new Queue<(int row, int column)>();
                queue.Enqueue((i, j));
                var blockCount = 0;
                var blockSum = 0L;

                while (queue.Count > 0)
                {
                    var (row, column) = queue.Dequeue();

                    if (row < 0 || row >= n || column < 0 || column >= n)
                    {
                        continue;
                    }

                    if (visited[row, column])
                    {
                        continue;
                    }

                    visited[row, column] = true;

                    if (grid[row][column] == blocked)
                    {
                        continue;
                    }

                    blockCount++;
                    blockSum += grid[row][column];

                    queue.Enqueue((row - 1, column));
                    queue.Enqueue((row + 1, column));
                    queue.Enqueue((row, column - 1));
                    queue.Enqueue((row, column + 1));
                }

                totalCount += blockCount;
                totalSum += blockSum;
                ans -= blockCount * blockSum;
            }
        }

        ans += totalCount * totalSum;
        return ans;
    }
}