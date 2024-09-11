using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1582_Special_Positions_in_a_Binary_Matrix;

/// <summary>
/// https://leetcode.com/submissions/detail/1119173258/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int NumSpecial(int[][] mat)
    {
        var m = mat.Length;
        var n = mat[0].Length;

        var specialRows = new HashSet<int>();

        for (var i = 0; i < m; i++)
        {
            var onesCount = 0;

            for (var j = 0; j < n; j++)
            {
                if (mat[i][j] == 1)
                {
                    onesCount++;

                    if (onesCount > 1)
                    {
                        break;
                    }
                }

                if (onesCount == 1)
                {
                    specialRows.Add(i);
                }
            }
        }

        var ans = 0;

        for (var j = 0; j < n; j++)
        {
            var onesCount = 0;
            var lastOneRow = -1;

            for (var i = 0; i < m; i++)
            {
                if (mat[i][j] != 1)
                {
                    continue;
                }

                lastOneRow = i;
                onesCount++;

                if (onesCount > 1)
                {
                    break;
                }
            }

            if (onesCount == 1 && specialRows.Contains(lastOneRow))
            {
                ans++;
            }
        }

        return ans;
    }
}
