using JetBrains.Annotations;

namespace LeetCode._0048_Rotate_Image;

/// <summary>
/// https://leetcode.com/submissions/detail/815519381/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public void Rotate(int[][] matrix)
    {
        var n = matrix.Length;

        for (var i = 0; i < (n + 1) / 2; i++)
        {
            for (var j = 0; j < n / 2; j++)
            {
                ref var leftTop = ref matrix[i][j];
                ref var rightTop = ref matrix[j][n - 1 - i];
                ref var rightBottom = ref matrix[n - 1 - i][n - 1 - j];
                ref var leftBottom = ref matrix[n - 1 - j][i];

                (rightTop, rightBottom, leftBottom, leftTop) = (leftTop, rightTop, rightBottom, leftBottom);
            }
        }
    }
}