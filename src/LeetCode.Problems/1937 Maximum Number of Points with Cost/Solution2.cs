namespace LeetCode.Problems._1937_Maximum_Number_of_Points_with_Cost;

/// <summary>
/// https://leetcode.com/submissions/detail/1358475129/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxPoints(int[][] points)
    {
        var m = points.Length;
        var n = points[0].Length;

        var previousRow = new long[n];

        for (var column = 0; column < n; column++)
        {
            previousRow[column] = points[0][column];
        }

        for (var row = 1; row < m; row++)
        {
            var leftMax = new long[n];

            for (var column = 0; column < n; column++)
            {
                leftMax[column] = Math.Max(previousRow[column], column == 0 ? long.MinValue : leftMax[column - 1] - 1);
            }

            var rightMax = new long[n];

            for (var column = n - 1; column >= 0; column--)
            {
                rightMax[column] = Math.Max(previousRow[column], column == n - 1 ? long.MinValue : rightMax[column + 1] - 1);
            }

            var currentRow = new long[n];

            for (var column = 0; column < n; column++)
            {
                currentRow[column] = points[row][column] + Math.Max(leftMax[column], rightMax[column]);
            }

            previousRow = currentRow;
        }

        return previousRow.Max();
    }
}
