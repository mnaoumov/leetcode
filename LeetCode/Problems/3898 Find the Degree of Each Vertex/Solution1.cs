namespace LeetCode.Problems._3898_Find_the_Degree_of_Each_Vertex;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-497/problems/find-the-degree-of-each-vertex/submissions/1975901752/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindDegrees(int[][] matrix)
    {
        var n = matrix.Length;
        var ans = new int[n];

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (matrix[i][j] != 1)
                {
                    continue;
                }

                ans[i]++;
                ans[j]++;
            }
        }

        return ans;
    }
}
