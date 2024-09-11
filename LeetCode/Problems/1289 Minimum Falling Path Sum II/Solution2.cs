namespace LeetCode.Problems._1289_Minimum_Falling_Path_Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1242208005/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinFallingPathSum(int[][] grid)
    {
        var n = grid.Length;

        if (n == 1)
        {
            return grid[0][0];
        }

        var previousExclusiveMins = new int[n];

        for (var row = 0; row < n; row++)
        {
            var mins = new int[n];
            for (var column = 0; column < n; column++)
            {
                mins[column] = grid[row][column] + previousExclusiveMins[column];
            }

            var minsLeft = new int[n];
            minsLeft[0] = int.MaxValue;

            for (var column = 1; column < n; column++)
            {
                minsLeft[column] = Math.Min(minsLeft[column - 1], mins[column - 1]);
            }

            var minsRight = new int[n];
            minsRight[^1] = int.MaxValue;

            for (var column = n - 2; column >= 0; column--)
            {
                minsRight[column] = Math.Min(minsRight[column + 1], mins[column + 1]);
            }

            for (var column = 0; column < n; column++)
            {
                previousExclusiveMins[column] = Math.Min(minsLeft[column], minsRight[column]);
            }
        }

        return previousExclusiveMins.Min();
    }
}
