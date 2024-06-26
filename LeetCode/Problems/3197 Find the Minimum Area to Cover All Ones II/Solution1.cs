using JetBrains.Annotations;

namespace LeetCode.Problems._3197_Find_the_Minimum_Area_to_Cover_All_Ones_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-403/submissions/detail/1297316422/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinimumSum(int[][] grid)
    {
        const int impossible = 1000;
        var m = grid.Length;
        var n = grid[0].Length;

        return MinimumSum2(0, 0, m - 1, n - 1, 3);

        int MinimumSum2(int top, int left, int bottom, int right, int rectangleCount)
        {
            if (top > bottom || left > right)
            {
                if (rectangleCount == 0)
                {
                    return 0;
                }

                return impossible;
            }

            var area = (bottom - top + 1) * (right - left + 1);
            if (area < rectangleCount)
            {
                return impossible;
            }

            var minRow = bottom + 1;
            var maxRow = top - 1;
            var minColumn = right + 1;
            var maxColumn = left - 1;
            var hasOnes = false;

            for (var row = top; row <= bottom; row++)
            {
                for (var column = left; column <= right; column++)
                {
                    if (grid[row][column] != 1)
                    {
                        continue;
                    }

                    minRow = Math.Min(minRow, row);
                    maxRow = Math.Max(maxRow, row);
                    minColumn = Math.Min(minColumn, column);
                    maxColumn = Math.Max(maxColumn, column);
                    hasOnes = true;
                }
            }

            if (!hasOnes)
            {
                return rectangleCount;
            }

            if (rectangleCount == 0)
            {
                return impossible;
            }

            var ans = impossible;

            for (var row = minRow; row <= maxRow; row++)
            {
                for (var column = minColumn; column <= maxColumn; column++)
                {
                    var area2 = (row - minRow + 1) * (column - minColumn + 1);

                    for (var bottomRectangleCount = 0; bottomRectangleCount < rectangleCount; bottomRectangleCount++)
                    {
                        ans = Math.Min(ans,
                            area2
                            + MinimumSum2(row + 1, left, bottom, right, bottomRectangleCount)
                            + MinimumSum2(minRow, column + 1, row, right,
                                rectangleCount - 1 - bottomRectangleCount));
                    }
                }
            }

            return ans;
        }
    }
}
