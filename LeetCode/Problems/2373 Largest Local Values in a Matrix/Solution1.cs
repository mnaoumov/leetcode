using JetBrains.Annotations;

namespace LeetCode._2373_Largest_Local_Values_in_a_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/1255723425/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] LargestLocal(int[][] grid)
    {
        var n = grid.Length;

        var ans = Enumerable.Range(0, n - 2).Select(_ => new int[n - 2]).ToArray();

        for (var i = 0; i < n - 2; i++)
        {
            for (var j = 0; j < n - 2; j++)
            {
                ans[i][j] = int.MinValue;

                for (var k = i; k < i + 3; k++)
                {
                    for (var l = j; l < j + 3; l++)
                    {
                        ans[i][j] = Math.Max(ans[i][j], grid[k][l]);
                    }
                }
            }
        }

        return ans;
    }
}
