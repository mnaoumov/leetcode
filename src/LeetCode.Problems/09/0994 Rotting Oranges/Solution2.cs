namespace LeetCode.Problems._0994_Rotting_Oranges;

/// <summary>
/// https://leetcode.com/submissions/detail/906895183/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int OrangesRotting(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var queue = new Queue<(int i, int j)>();
        var freshOrangeCount = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                switch (grid[i][j])
                {
                    case 2:
                        EnqueueNeighbors(i, j);
                        break;
                    case 1:
                        freshOrangeCount++;
                        break;
                }
            }
        }

        var result = 0;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            var hadFreshOranges = false;

            for (var k = 0; k < count; k++)
            {
                var (i, j) = queue.Dequeue();

                if (i < 0 || i >= m || j < 0 || j >= n)
                {
                    continue;
                }

                if (grid[i][j] != 1)
                {
                    continue;
                }

                hadFreshOranges = true;
                freshOrangeCount--;
                grid[i][j] = 2;

                EnqueueNeighbors(i, j);
            }

            if (!hadFreshOranges)
            {
                break;
            }

            result++;
        }

        return freshOrangeCount == 0 ? result : -1;

        void EnqueueNeighbors(int i, int j)
        {
            queue.Enqueue((i + 1, j));
            queue.Enqueue((i - 1, j));
            queue.Enqueue((i, j + 1));
            queue.Enqueue((i, j - 1));
        }
    }
}
