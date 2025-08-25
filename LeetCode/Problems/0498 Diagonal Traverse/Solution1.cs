namespace LeetCode.Problems._0498_Diagonal_Traverse;

/// <summary>
/// https://leetcode.com/problems/diagonal-traverse/submissions/1747186736/?envType=daily-question&envId=2025-08-25
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindDiagonalOrder(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var list = new List<int>(m * n);

        for (var sum = 0; sum <= m - 1 + n - 1; sum++)
        {
            if (sum % 2 == 0)
            {
                var startRow = Math.Min(sum, m - 1);
                var startCol = sum - startRow;
                var row = startRow;
                var col = startCol;
                while (row >= 0 && col < n)
                {
                    list.Add(mat[row][col]);
                    row--;
                    col++;
                }
            }
            else
            {
                var startCol = Math.Min(sum, n - 1);
                var startRow = sum - startCol;
                var row = startRow;
                var col = startCol;
                while (row < m && col >= 0)
                {
                    list.Add(mat[row][col]);
                    row++;
                    col--;
                }
            }
        }

        return list.ToArray();
    }
}
