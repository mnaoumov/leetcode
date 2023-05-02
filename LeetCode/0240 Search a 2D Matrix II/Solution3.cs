using JetBrains.Annotations;

namespace LeetCode._0240_Search_a_2D_Matrix_II;

/// <summary>
/// https://leetcode.com/submissions/detail/874669826/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        if (target < matrix[0][0] || target > matrix[m - 1][n - 1])
        {
            return false;
        }

        return Search((0, 0), (m - 1, n - 1));

        bool Search((int x, int y) leftTop, (int x, int y) rightBottom)
        {
            if (leftTop.x > rightBottom.x || leftTop.y > rightBottom.y)
            {
                return false;
            }

#pragma warning disable IDE0042
            var mid = (x: Half(leftTop.x, rightBottom.x), y: Half(leftTop.y, rightBottom.y));
#pragma warning restore IDE0042

            var value = matrix[mid.x][mid.y];

            if (value == target)
            {
                return true;
            }

            if (value > target)
            {
                return Search(leftTop, (rightBottom.x, mid.y - 1)) ||
                       Search((leftTop.x, mid.y), (mid.x - 1, rightBottom.y));
            }

            return Search((mid.x + 1, leftTop.y), rightBottom) ||
                   Search((leftTop.x, mid.y + 1), (mid.x, rightBottom.y));
        }
    }

    private static int Half(int a, int b) => a + (b - a >> 1);
}
