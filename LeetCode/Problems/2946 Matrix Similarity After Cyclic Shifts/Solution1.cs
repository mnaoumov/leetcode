using JetBrains.Annotations;

namespace LeetCode.Problems._2946_Matrix_Similarity_After_Cyclic_Shifts;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-373/submissions/detail/1106458692/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool AreSimilar(int[][] mat, int k)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        k %= n;

        if (k == 0)
        {
            return true;
        }

        for (var i = 0; i < m; i++)
        {
            var delta = i % 2 == 1 ? k : -k;

            for (var j = 0; j < n; j++)
            {
                var shifted = ((j + delta) % n + n) % n;

                if (mat[i][shifted] != mat[i][j])
                {
                    return false;
                }
            }

        }

        return true;
    }
}
