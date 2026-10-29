namespace LeetCode.Problems._1878_Get_Biggest_Three_Rhombus_Sums_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/get-biggest-three-rhombus-sums-in-a-grid/submissions/1949577517/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] GetBiggestThree(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var maxSums = new SortedSet<int>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var maxK = new[] { (m - 1 - i) / 2, j, n - 1 - j }.Min();

                for (var k = 0; k <= maxK; k++)
                {
                    int sum;

                    if (k == 0)
                    {
                        sum = grid[i][j];
                    }
                    else
                    {
                        sum = grid[i][j] + grid[i + k][j + k] + grid[i + 2 * k][j] + grid[i + k][j - k];

                        for (var l = 1; l < k; l++)
                        {
                            sum += grid[i + l][j + l] + grid[i + k + l][j + k - l] + grid[i + 2 * k - l][j - l] +
                                   grid[i + k - l][j - k + l];
                        }
                    }

                    maxSums.Add(sum);

                    if (maxSums.Count > 3)
                    {
                        maxSums.Remove(maxSums.Min);
                    }
                }
            }
        }

        return maxSums.Reverse().ToArray();
    }
}
