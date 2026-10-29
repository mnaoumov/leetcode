namespace LeetCode.Problems._0063_Unique_Paths_II;

/// <summary>
/// https://leetcode.com/submissions/detail/819557410/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const int Obstacle = 1;

    public int UniquePathsWithObstacles(int[][] obstacleGrid)
    {
        var m = obstacleGrid.Length;
        var n = obstacleGrid[0].Length;

        var cache = new int?[m, n];

        return Get(0, 0);

        int Get(int i, int j)
        {
            if (i >= m || j >= n)
            {
                return 0;
            }

            if (cache[i, j] is not { } result)
            {
                cache[i, j] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (obstacleGrid[i][j] == Obstacle)
                {
                    return 0;
                }

                if (i == m - 1 && j == n - 1)
                {
                    return 1;
                }

                return Get(i + 1, j) + Get(i, j + 1);
            }
        }
    }
}
