using JetBrains.Annotations;

namespace LeetCode.Problems._0840_Magic_Squares_In_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1349426707/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumMagicSquaresInside(int[][] grid)
    {
        var row = grid.Length;
        var col = grid[0].Length;
        var ans = 0;

        for (var i = 0; i < row - 2; i++)
        {
            for (var j = 0; j < col - 2; j++)
            {
                if (IsMagicSquare(grid, i, j))
                {
                    ans++;
                }
            }
        }

        return ans;
    }

    private static bool IsMagicSquare(int[][] grid, int i, int j)
    {
        var values = new HashSet<int>();
        var rowSums = new int[3];
        var colSums = new int[3];
        var diagonalSum = 0;
        var antiDiagonalSum = 0;

        for (var k = 0; k < 3; k++)
        {
            for (var l = 0; l < 3; l++)
            {
                var value = grid[i + k][j + l];
                if (value < 1 || value > 9 || !values.Add(value))
                {
                    return false;
                }

                rowSums[k] += value;
                colSums[l] += value;
                if (k == l)
                {
                    diagonalSum += value;
                }

                if (k + l == 2)
                {
                    antiDiagonalSum += value;
                }
            }
        }

        return rowSums.Concat(colSums).Concat(new[] { diagonalSum, antiDiagonalSum }).All(sum => sum == 15);
    }
}
