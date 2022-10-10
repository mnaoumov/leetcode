namespace LeetCode._0064_Minimum_Path_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/819580557/
/// </summary>
public class Solution1 : ISolution
{
    public int MinPathSum(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var cache = new int?[m, n];
        return Get(0, 0);

        int Get(int i, int j)
        {
            if (cache[i, j] is not { } result)
            {
                cache[i, j] = result = Calculate();
            }

            return result;

            int Calculate()
            {
                if (i == m - 1 && j == n - 1)
                {
                    return grid[i][j];
                }

                var moveRightResult = j < n - 1 ? Get(i, j + 1) : int.MaxValue;
                var moveDownResult = i < m - 1 ? Get(i + 1, j) : int.MaxValue;

                return grid[i][j] + Math.Min(moveRightResult, moveDownResult);
            }
        }
    }
}