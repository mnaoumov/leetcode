using JetBrains.Annotations;

namespace LeetCode._0079_Word_Search;

/// <summary>
/// https://leetcode.com/submissions/detail/821721381/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public bool Exist(char[][] board, string word)
    {
        var m = board.Length;
        var n = board[0].Length;
        var boardLetterTaken = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (ExistsAt(i, j, 0))
                {
                    return true;
                }
            }
        }

        return false;

        bool ExistsAt(int i, int j, int letterIndex)
        {
            if (letterIndex >= word.Length)
            {
                return true;
            }

            if (i < 0 || i >= m || j < 0 || j >= n)
            {
                return false;
            }

            if (board[i][j] != word[letterIndex])
            {
                return false;
            }

            if (boardLetterTaken[i, j])
            {
                return false;
            }

            boardLetterTaken[i, j] = true;

            var result =
                ExistsAt(i + 1, j, letterIndex + 1)
                || ExistsAt(i - 1, j, letterIndex + 1)
                || ExistsAt(i, j + 1, letterIndex + 1)
                || ExistsAt(i, j - 1, letterIndex + 1);

            boardLetterTaken[i, j] = false;

            return result;
        }
    }
}