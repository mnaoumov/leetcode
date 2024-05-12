using JetBrains.Annotations;

namespace LeetCode.Problems._2661_First_Completely_Painted_Row_or_Column;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-343/submissions/detail/941859535/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FirstCompleteIndex(int[] arr, int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var rowCounts = new int[m];
        var columnCounts = new int[n];

        var numMatMap = new (int row, int column)[m * n + 1];

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                numMatMap[mat[row][column]] = (row, column);
            }
        }

        for (var i = 0; i < arr.Length; i++)
        {
            var num = arr[i];
            var (row, column) = numMatMap[num];
            rowCounts[row]++;
            columnCounts[column]++;

            if (rowCounts[row] == n || columnCounts[column] == m)
            {
                return i;
            }
        }

        throw new InvalidOperationException();
    }
}
