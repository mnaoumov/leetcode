namespace LeetCode._0059_Spiral_Matrix_II;

/// <summary>
/// https://leetcode.com/submissions/detail/819462926/
/// </summary>
public class Solution1 : ISolution
{
    public int[][] GenerateMatrix(int n)
    {
        var result = Enumerable.Range(0, n).Select(_ => new int[n]).ToArray();

        var i = 0;
        var j = -1;
        var di = 0;
        var dj = 1;

        var iMin = 0;
        var iMax = n - 1;
        var jMin = 0;
        var jMax = n - 1;


        for (var x = 1; x <= n * n; x++)
        {
            while (true)
            {
                i += di;
                j += dj;

                var canMove = iMin <= i && i <= iMax && jMin <= j && j <= jMax;

                if (canMove)
                {
                    break;
                }

                i -= di;
                j -= dj;

                (di, dj) = (dj, -di);

                if (di == -1)
                {
                    iMin++;
                    iMax--;
                }

                if (dj == 1)
                {
                    jMin++;
                    jMax--;
                }
            }

            result[i][j] = x;
        }

        return result;
    }
}