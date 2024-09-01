using JetBrains.Annotations;

namespace LeetCode.Problems._2022_Convert_1D_Array_Into_2D_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1374735506/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] Construct2DArray(int[] original, int m, int n)
    {
        if (original.Length != m * n)
        {
            return Array.Empty<int[]>();
        }

        var ans = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                ans[i][j] = original[i * n + j];
            }
        }

        return ans;
    }
}
