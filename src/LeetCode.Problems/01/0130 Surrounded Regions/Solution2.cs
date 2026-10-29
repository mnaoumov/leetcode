namespace LeetCode.Problems._0130_Surrounded_Regions;

/// <summary>
/// https://leetcode.com/problems/surrounded-regions/submissions/836849443/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    private const char Cross = 'X';

    public void Solve(char[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        var rowRanges = new Dictionary<int, (int left, int right)>();

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

            rowRanges[i] = (left, right);
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

            for (var i = top + 1; i < bottom; i++)
            {
                if (rowRanges.TryGetValue(i, out var rowRange) && rowRange.left <= i && i <= rowRange.right)
                {
                    board[i][j] = Cross;
                }
            }
        }
    }
}
