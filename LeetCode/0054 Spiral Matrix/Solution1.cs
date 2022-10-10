namespace LeetCode._0054_Spiral_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/819411014/
/// </summary>
public class Solution1 : ISolution
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        var result = new List<int>();

        var i = 0;
        var j = -1;
        var di = 0;
        var dj = 1;

        var m = matrix.Length;
        var n = matrix[0].Length;
        var iMin = 0;
        var iMax = m - 1;
        var jMin = 0;
        var jMax = n - 1;

        while (true)
        {
            bool canMove = true;
            bool isOver;

            while (true)
            {
                i += di;
                j += dj;

                var newCanMove = iMin <= i && i <= iMax && jMin <= j && j <= jMax;
                isOver = !canMove && !newCanMove;
                canMove = newCanMove;

                if (canMove || isOver)
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

            if (isOver)
            {
                break;
            }

            result.Add(matrix[i][j]);
        }

        return result;
    }
}