using JetBrains.Annotations;

namespace LeetCode._2713_Maximum_Strictly_Increasing_Cells_in_a_Matrix;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxIncreasingCells(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var sortedRows = mat.Select(row => row.OrderBy(x => x).ToArray()).ToArray();
        var sortedColumns = Enumerable.Range(0, n)
            .Select(columnIndex => mat.Select(row => row[columnIndex]).OrderBy(x => x).ToArray()).ToArray();

        var maxPaths = new int[m, n];

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (maxPaths[i, j] != 0)
                {
                    continue;
                }

                Dfs(i, j);
            }
        }

        return ans;

        void Dfs(int i, int j)
        {
            var num = mat[i][j];

//            sortedRows[i]
        }

    }
}
