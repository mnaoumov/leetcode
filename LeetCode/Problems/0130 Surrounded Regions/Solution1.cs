using JetBrains.Annotations;

namespace LeetCode.Problems._0130_Surrounded_Regions;

/// <summary>
/// https://leetcode.com/problems/surrounded-regions/submissions/836609491/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    private const char Cross = 'X';

    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        for (var i = 1; i < m - 1; i++)
        {
            var left = 0;
            var right = n - 1;

            while (right - left >= 2 && board[i][left] != Cross)
            {
                left++;
            }

            while (right - left >= 2 && board[i][right] != Cross)
            {
                right--;
            }

            if (right - left < 2)
            {
                continue;
            }

            for (var j = left + 1; j < right; j++)
            {
                board[i][j] = Cross;
            }
        }

        for (var j = 1; j < n - 1; j++)
        {
            var top = 0;
            var bottom = m - 1;

            while (bottom - top >= 2 && board[top][j] != Cross)
            {
                top++;
            }

            while (bottom - top >= 2 && board[bottom][j] != Cross)
            {
                bottom--;
            }

            if (bottom - top < 2)
            {
                continue;
            }

            for (var i = top + 1; j < bottom; j++)
            {
                board[i][j] = Cross;
            }
        }
    }
}
