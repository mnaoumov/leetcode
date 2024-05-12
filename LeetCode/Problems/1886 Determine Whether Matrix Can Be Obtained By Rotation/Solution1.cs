using JetBrains.Annotations;

namespace LeetCode.Problems._1886_Determine_Whether_Matrix_Can_Be_Obtained_By_Rotation;

/// <summary>
/// https://leetcode.com/submissions/detail/934394265/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool FindRotation(int[][] mat, int[][] target)
    {
        var n = mat.Length;

        for (var k = 0; k < 4; k++)
        {
            var result = true;

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var i2 = i;
                    var j2 = j;

                    for (var l = 0; l < k; l++)
                    {
                        (i2, j2) = (j2, n - 1 - i2);
                    }

                    if (mat[i][j] == target[i2][j2])
                    {
                        continue;
                    }

                    result = false;
                    break;
                }
            }

            if (result)
            {
                return true;
            }
        }

        return false;
    }
}
