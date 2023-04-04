using JetBrains.Annotations;

namespace LeetCode._1351_Count_Negative_Numbers_in_a_Sorted_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/927599719/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountNegatives(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        return Count(0, 0, m - 1, n - 1);

        int Count(int topRow, int leftColumn, int bottomRow, int rightColumn)
        {
            if (topRow > bottomRow || leftColumn > rightColumn)
            {
                return 0;
            }

            var middleRow = topRow + (bottomRow - topRow >> 1);
            var middleColumn = leftColumn + (rightColumn - leftColumn >> 1);

            return grid[middleRow][middleColumn] >= 0
                ? Count(topRow, middleColumn + 1, middleRow, rightColumn) +
                  Count(middleRow + 1, leftColumn, bottomRow, rightColumn)
                : (bottomRow - middleRow + 1) * (rightColumn - middleColumn + 1) +
                  Count(topRow, leftColumn, middleRow - 1, rightColumn) +
                  Count(middleRow, leftColumn, bottomRow, middleColumn - 1);
        }
    }
}
