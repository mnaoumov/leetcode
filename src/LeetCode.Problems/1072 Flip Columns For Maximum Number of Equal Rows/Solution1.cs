namespace LeetCode.Problems._1072_Flip_Columns_For_Maximum_Number_of_Equal_Rows;

/// <summary>
/// https://leetcode.com/submissions/detail/1459668038/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxEqualRowsAfterFlips(int[][] matrix)
    {
        var ans = 0;
        var m = matrix.Length;
        var n = matrix[0].Length;

        for (var i = 0; i < m; i++)
        {
            var rowCount = 0;

            for (var j = 0; j < m; j++)
            {
                var flip = matrix[i][0] ^ matrix[j][0];
                var isGoodRow = true;

                for (var k = 1; k < n; k++)
                {
                    if ((matrix[i][k] ^ matrix[j][k]) == flip)
                    {
                        continue;
                    }

                    isGoodRow = false;
                    break;
                }

                if (isGoodRow)
                {
                    rowCount++;
                }
            }

            ans = Math.Max(ans, rowCount);
        }

        return ans;
    }
}
