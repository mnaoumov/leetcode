using JetBrains.Annotations;

namespace LeetCode.Problems._0661_Image_Smoother;

/// <summary>
/// https://leetcode.com/submissions/detail/1123785246/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[][] ImageSmoother(int[][] img)
    {
        var m = img.Length;
        var n = img[0].Length;

        var ans = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var sum = 0;
                var count = 0;

                for (var i2 = Math.Max(i - 1, 0); i2 <= Math.Min(i + 1, m - 1); i2++)
                {
                    for (var j2 = Math.Max(j - 1, 0); i2 <= Math.Min(j + 1, n - 1); j2++)
                    {
                        sum += img[i2][j2];
                        count++;
                    }
                }

                ans[i][j] = sum / count;
            }
        }

        return ans;
    }
}
