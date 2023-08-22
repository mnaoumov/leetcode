using JetBrains.Annotations;

namespace LeetCode._0723_Candy_Crush;

/// <summary>
/// https://leetcode.com/submissions/detail/1028182312/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] CandyCrush(int[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        var ans = board.Select(row => row.ToArray()).ToArray();

        while (true)
        {
            var isStable = true;

            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    var value = ans[i][j];

                    if (value == 0)
                    {
                        continue;
                    }

                    if (i >= 2 && value == Math.Abs(ans[i - 1][j]) && value == Math.Abs(ans[i - 2][j]))
                    {
                        isStable = false;
                        ans[i][j] = -value;
                        ans[i - 1][j] = -value;
                        ans[i - 2][j] = -value;
                    }

                    // ReSharper disable once InvertIf
                    if (j >= 2 && value == Math.Abs(ans[i][j - 1]) && value == Math.Abs(ans[i][j - 2]))
                    {
                        isStable = false;
                        ans[i][j] = -value;
                        ans[i][j - 1] = -value;
                        ans[i][j - 2] = -value;
                    }
                }
            }

            if (isStable)
            {
                break;
            }

            for (var j = 0; j < n; j++)
            {
                var k = m - 1;

                for (var i = m - 1; i >= 0; i--)
                {
                    if (ans[i][j] == 0)
                    {
                        break;
                    }

                    if (ans[i][j] < 0)
                    {
                        continue;
                    }

                    ans[k][j] = ans[i][j];
                    k--;
                }

                for (var i = k; i >= 0; i--)
                {
                    ans[i][j] = 0;
                }
            }
        }

        return ans;
    }
}
