using JetBrains.Annotations;

namespace LeetCode._0994_Rotting_Oranges;

/// <summary>
/// https://leetcode.com/submissions/detail/906888506/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
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
                        queue.Enqueue((i, j));
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

                switch (grid[i][j])
                {
                    case 0:
                        continue;
                    case 1:
                        hadFreshOranges = true;
                        freshOrangeCount--;
                        grid[i][j] = 2;
                        break;
                    default:
                        {
                            if (result > 0)
                            {
                                continue;
                            }

                            break;
                        }
                }

                queue.Enqueue((i + 1, j));
                queue.Enqueue((i - 1, j));
                queue.Enqueue((i, j + 1));
                queue.Enqueue((i, j - 1));
            }

            if (hadFreshOranges)
            {
                result++;
            }
            else if (result > 0)
            {
                break;
            }
        }

        return freshOrangeCount == 0 ? result : -1;
    }
}
