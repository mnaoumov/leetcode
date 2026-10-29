namespace LeetCode.Problems._1504_Count_Submatrices_With_All_Ones;

/// <summary>
/// https://leetcode.com/problems/count-submatrices-with-all-ones/submissions/1743757710/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSubmat(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var oneColumnsAbove = new int[n];

        var ans = 0;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                if (mat[row][column] == 1)
                {
                    oneColumnsAbove[column]++;
                }
                else
                {
                    oneColumnsAbove[column] = 0;
                }

                var min = int.MaxValue;
                for (var previousColumn = column; previousColumn >= 0; previousColumn--)
                {
                    min = Math.Min(min, oneColumnsAbove[previousColumn]);
                    if (min == 0)
                    {
                        break;
                    }

                    ans += min;
                }
            }
        }

        return ans;
    }
}
