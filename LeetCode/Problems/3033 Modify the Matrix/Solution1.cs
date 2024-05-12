using JetBrains.Annotations;

namespace LeetCode._3033_Modify_the_Matrix;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-384/submissions/detail/1171873111/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] ModifiedMatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var ans = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        for (var j = 0; j < n; j++)
        {
            var max = int.MinValue;
            var replaceIndices = new List<int>();

            for (var i = 0; i < m; i++)
            {
                ans[i][j] = matrix[i][j];
                max = Math.Max(max, ans[i][j]);

                if (ans[i][j] == -1)
                {
                    replaceIndices.Add(i);
                }
            }

            foreach (var i in replaceIndices)
            {
                ans[i][j] = max;
            }
        }

        return ans;
    }
}
