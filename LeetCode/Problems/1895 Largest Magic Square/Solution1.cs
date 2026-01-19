namespace LeetCode.Problems._1895_Largest_Magic_Square;

/// <summary>
/// https://leetcode.com/problems/largest-magic-square/submissions/1888311915/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestMagicSquare(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        for (var k = Math.Min(m, n); k >= 2; k--)
        {
            for (var i = 0; i <= m - k; i++)
            {
                for (var j = 0; j <= n - k; j++)
                {
                    var sum = Enumerable.Range(0, k).Select(t => grid[i][j + t]).Sum();
                    var isMagicSquare = true;

                    for (var s = 1; s < k; s++)
                    {
                        var rowSum = Enumerable.Range(0, k).Select(t => grid[i + s][j + t]).Sum();
                        if (rowSum == sum)
                        {
                            continue;
                        }

                        isMagicSquare = false;
                        break;
                    }

                    if (!isMagicSquare)
                    {
                        continue;
                    }

                    for (var t = 0; t < k; t++)
                    {
                        var columnSum = Enumerable.Range(0, k).Select(s => grid[i + s][j + t]).Sum();
                        if (columnSum == sum)
                        {
                            continue;
                        }

                        isMagicSquare = false;
                        break;
                    }

                    if (!isMagicSquare)
                    {
                        continue;
                    }

                    var diagonalSum = Enumerable.Range(0, k).Select(u => grid[i + u][j + u]).Sum();
                    if (diagonalSum != sum)
                    {
                        continue;
                    }

                    var antiDiagonalSum = Enumerable.Range(0, k).Select(u => grid[i + u][j + k - 1 - u]).Sum();
                    if (antiDiagonalSum != sum)
                    {
                        continue;
                    }

                    return k;
                }
            }
        }

        return 1;
    }
}
