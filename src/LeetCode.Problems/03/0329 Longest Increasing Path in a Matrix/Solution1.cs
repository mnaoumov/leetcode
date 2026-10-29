namespace LeetCode.Problems._0329_Longest_Increasing_Path_in_a_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/926228110/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestIncreasingPath(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var lengths = new int[m, n];
        var result = 0;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                result = Math.Max(result, Dfs(i, j));
            }
        }

        return result;

        int Dfs(int i, int j)
        {
            if (lengths[i, j] != 0)
            {
                return lengths[i, j];
            }

            var maxLength = 1;

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                if (matrix[i][j] >= matrix[nextI][nextJ])
                {
                    continue;
                }

                maxLength = Math.Max(maxLength, Dfs(nextI, nextJ) + 1);
            }

            lengths[i, j] = maxLength;
            return maxLength;
        }
    }
}
