using JetBrains.Annotations;

namespace LeetCode.Problems._3212_Count_Submatrices_With_Equal_Frequency_of_X_and_Y;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-405/submissions/detail/1312304555/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfSubmatrices(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var counts = new (int xCount, int yCount)[m, n];
        var ans = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var countUp = i > 0 ? counts[i - 1, j] : (xCount: 0, yCount: 0);
                var countLeft = j > 0 ? counts[i, j - 1] : (xCount: 0, yCount: 0);
                var countUpLeft = i > 0 && j > 0 ? counts[i - 1, j - 1] : (xCount: 0, yCount: 0);
                counts[i, j] = (countUp.xCount + countLeft.xCount - countUpLeft.xCount + (grid[i][j] == 'X' ? 1 : 0),
                    countUp.yCount + countLeft.yCount - countUpLeft.yCount + (grid[i][j] == 'Y' ? 1 : 0));

                if (counts[i, j].xCount == counts[i, j].yCount && counts[i, j].xCount > 0)
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
