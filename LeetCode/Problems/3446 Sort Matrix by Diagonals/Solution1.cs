namespace LeetCode.Problems._3446_Sort_Matrix_by_Diagonals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-436/problems/sort-matrix-by-diagonals/submissions/1536408758/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] SortMatrix(int[][] grid)
    {
        var n = grid.Length;
        var ans = Enumerable.Range(0, n).Select(_ => new int[n]).ToArray();

        for (var i = 0; i < n; i++)
        {
            var diagonalValues = new int[n - i];

            for (var j = 0; j < n - i; j++)
            {
                diagonalValues[j] = grid[i + j][j];
            }

            Array.Sort(diagonalValues, (a, b) => b - a);

            for (var j = 0; j < n - i; j++)
            {
                ans[i + j][j] = diagonalValues[j];
            }
        }

        for (var j = 1; j < n; j++)
        {
            var diagonalValues = new int[n - j];

            for (var i = 0; i < n - j; i++)
            {
                diagonalValues[i] = grid[i][i + j];
            }

            Array.Sort(diagonalValues);

            for (var i = 0; i < n - j; i++)
            {
                ans[i][i + j] = diagonalValues[i];
            }
        }

        return ans;
    }
}
