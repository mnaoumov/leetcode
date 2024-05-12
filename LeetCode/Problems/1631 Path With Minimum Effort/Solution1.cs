using JetBrains.Annotations;

namespace LeetCode.Problems._1631_Path_With_Minimum_Effort;

/// <summary>
/// https://leetcode.com/submissions/detail/914716309/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumEffortPath(int[][] heights)
    {
        var rows = heights.Length;
        var columns = heights[0].Length;

        var low = 0;
        var high = 1_000_000;
        var deltas = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (DoesRouteExist(mid))
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;

        bool DoesRouteExist(int maxEffort)
        {
            var seen = new bool[rows, columns];

            return Dfs(0, 0);

            bool Dfs(int row, int col)
            {
                if (row == rows - 1 && col == columns - 1)
                {
                    return true;
                }

                seen[row, col] = true;

                foreach (var (dRow, dCol) in deltas)
                {
                    var nextRow = row + dRow;
                    var nextCol = col + dCol;

                    if (nextRow < 0 || nextCol < 0 || nextRow >= rows || nextCol >= columns || seen[nextRow, nextCol])
                    {
                        continue;
                    }

                    if (Math.Abs(heights[nextRow][nextCol] - heights[row][col]) <= maxEffort && Dfs(nextRow, nextCol))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
