using JetBrains.Annotations;

namespace LeetCode._1706_Where_Will_the_Ball_Fall;

/// <summary>
/// https://leetcode.com/submissions/detail/834366324/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindBall(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        const int stuck = -1;

        var result = new int[n];

        for (var j = 0; j < n; j++)
        {
            result[j] = j;
            for (var i = 0; i < m; i++)
            {
                var currentDirection = grid[i][result[j]];
                var neighborColumn = result[j] + currentDirection;
                var neighborDirection = 0 <= neighborColumn && neighborColumn < n ? grid[i][neighborColumn] : -currentDirection;

                if (currentDirection != neighborDirection)
                {
                    result[j] = stuck;
                    break;
                }

                result[j] = neighborColumn;
            }
        }

        return result;
    }
}
