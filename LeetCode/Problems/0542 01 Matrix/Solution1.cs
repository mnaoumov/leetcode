using JetBrains.Annotations;

namespace LeetCode.Problems._0542_01_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/904852966/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] UpdateMatrix(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;
        const int unset = -1;

        var result = Enumerable.Range(0, m).Select(_ => Enumerable.Repeat(unset, n).ToArray()).ToArray();

        var queue = new Queue<(int row, int column, int distance)>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                if (mat[row][column] == 0)
                {
                    queue.Enqueue((row, column, 0));
                }
            }
        }

        var deltas = new (int dRow, int dColumn)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        while (queue.Count > 0)
        {
            var (row, column, distance) = queue.Dequeue();

            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                continue;
            }

            if (result[row][column] != unset)
            {
                continue;
            }

            result[row][column] = distance;

            foreach (var (dRow, dColumn) in deltas)
            {
                queue.Enqueue((row + dRow, column + dColumn, distance + 1));
            }
        }

        return result;
    }
}
