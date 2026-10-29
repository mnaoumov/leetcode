namespace LeetCode.Problems._0931_Minimum_Falling_Path_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/858892390/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinFallingPathSum(int[][] matrix)
    {
        var n = matrix.Length;

        var minFallingPathSums = new int[n, n];

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = 0; j < n; j++)
            {
                minFallingPathSums[i, j] = matrix[i][j] + GetMinFallingPaths(i + 1, j);
            }
        }

        return Enumerable.Range(0, n).Select(j => minFallingPathSums[0, j]).Min();

        int GetMinFallingPaths(int i, int j)
        {
            if (i == n)
            {
                return 0;
            }

            var candidates = new List<int> { minFallingPathSums[i, j] };

            if (j - 1 >= 0)
            {
                candidates.Add(minFallingPathSums[i, j - 1]);
            }

            if (j + 1 < n)
            {
                candidates.Add(minFallingPathSums[i, j + 1]);
            }

            return candidates.Min();
        }
    }
}
