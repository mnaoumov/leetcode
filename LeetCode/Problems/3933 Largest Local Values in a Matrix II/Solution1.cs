namespace LeetCode.Problems._3933_Largest_Local_Values_in_a_Matrix_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-502/problems/largest-local-values-in-a-matrix-ii/submissions/2005098576/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountLocalMaximums(int[][] matrix)
    {
        var n = matrix.Length;
        var m = matrix[0].Length;

        var ans = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < m; j++)
            {
                var x = matrix[i][j];

                if (x == 0)
                {
                    continue;
                }

                var isLocalMax = true;

                for (var k = Math.Max(i - x, 0); k <= Math.Min(i + x, n - 1); k++)
                {
                    for (var l = Math.Max(j - x, 0); l <= Math.Min(j + x, m - 1); l++)
                    {
                        if (Math.Abs(k - i) == x && Math.Abs(l - j) == x)
                        {
                            continue;
                        }

                        if (matrix[k][l] <= x)
                        {
                            continue;
                        }

                        isLocalMax = false;
                        break;
                    }

                    if (!isLocalMax)
                    {
                        break;
                    }
                }

                if (isLocalMax)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
