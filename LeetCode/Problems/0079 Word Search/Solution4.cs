using JetBrains.Annotations;

namespace LeetCode._0079_Word_Search;

/// <summary>
/// https://leetcode.com/submissions/detail/918859197/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var seen = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (Backtrack(i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;

        bool Backtrack(int i, int j, int letterIndex)
        {
            if (board[i][j] != word[letterIndex])
            {
                return false;
            }

            if (letterIndex == word.Length - 1)
            {
                return true;
            }

            seen[i, j] = true;
            var result = false;

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                if (seen[nextI, nextJ])
                {
                    continue;
                }

                result = Backtrack(nextI, nextJ, letterIndex + 1);

                if (result)
                {
                    break;
                }
            }

            seen[i, j] = false;
            return result;
        }
    }
}
