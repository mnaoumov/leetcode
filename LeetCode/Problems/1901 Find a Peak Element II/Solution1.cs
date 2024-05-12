using JetBrains.Annotations;

namespace LeetCode._1901_Find_a_Peak_Element_II;

/// <summary>
/// https://leetcode.com/submissions/detail/943264301/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindPeakGrid(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var low = 0;
        var high = n - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            var max = int.MinValue;
            var maxValueCell = (row: -1, column: -1);

            for (var row = 0; row < m; row++)
            {
                CompareMaxWithColumn(row, mid, updateIfEquals: true);
                CompareMaxWithColumn(row, mid - 1, updateIfEquals: false);
                CompareMaxWithColumn(row, mid + 1, updateIfEquals: false);
            }

            if (maxValueCell.column == mid)
            {
                return new[] { maxValueCell.row, maxValueCell.column };
            }

            if (maxValueCell.column < mid)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }

            continue;

            void CompareMaxWithColumn(int row, int column, bool updateIfEquals)
            {
                if (row < 0 || row >= m || column < 0 || column >= n)
                {
                    return;
                }

                if (mat[row][column] < max || mat[row][column] == max && !updateIfEquals)
                {
                    return;
                }

                maxValueCell = (row, column);
                max = mat[row][column];
            }
        }

        throw new InvalidOperationException();
    }
}
