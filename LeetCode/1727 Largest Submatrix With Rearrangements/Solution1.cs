using JetBrains.Annotations;

namespace LeetCode._1727_Largest_Submatrix_With_Rearrangements;

/// <summary>
/// https://leetcode.com/submissions/detail/1106421449/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LargestSubmatrix(int[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var consecutiveOneCounts = new int[m, n];

        for (var j = 0; j < n; j++)
        {
            for (var i = 0; i < m; i++)
            {
                if (matrix[i][j] == 1)
                {
                    consecutiveOneCounts[i, j] = (i > 0 ? consecutiveOneCounts[i - 1, j] : 0) + 1;
                }
            }
        }

        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            var width = 1;

            foreach (var height in Enumerable.Range(0, n).Select(j => consecutiveOneCounts[i, j]).OrderByDescending(x => x))
            {
                if (height == 0)
                {
                    break;
                }

                ans = Math.Max(ans, width * height);
                width++;
            }
        }

        return ans;
    }
}
