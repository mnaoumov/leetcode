using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0079_Word_Search;

/// <summary>
/// https://leetcode.com/submissions/detail/198314734/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool Exist(char[][] board, string word) => Exist(ArrayHelper.ArrayOfArraysTo2D(board), word);

    public bool Exist(char[,] board, string word)
    {
        var m = board.GetLength(0);
        var n = board.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                var visited = new bool[m, n];
                if (Exist(board, word, i, j, 0, visited))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private bool Exist(char[,] board, string word, int i, int j, int wordIndex, bool[,] visited)
    {
        if (wordIndex >= word.Length)
        {
            return true;
        }

        var m = board.GetLength(0);
        var n = board.GetLength(1);
        if (i < 0 || j < 0 || i >= m || j >= n)
        {
            return false;
        }

        if (visited[i, j])
        {
            return false;
        }

        if (board[i, j] != word[wordIndex])
        {
            return false;
        }

        visited[i, j] = true;

        var result =
            Exist(board, word, i + 1, j, wordIndex + 1, visited)
            || Exist(board, word, i - 1, j, wordIndex + 1, visited)
            || Exist(board, word, i, j + 1, wordIndex + 1, visited)
            || Exist(board, word, i, j - 1, wordIndex + 1, visited);

        visited[i, j] = false;

        return result;
    }
}
