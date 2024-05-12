using JetBrains.Annotations;

namespace LeetCode.Problems._0212_Word_Search_II;

/// <summary>
/// https://leetcode.com/problems/word-search-ii/submissions/837090860/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
        var letterCounts = board.SelectMany(row => row).GroupBy(letter => letter)
            .ToDictionary(g => g.Key, g => g.Count());

        words = words.Where(HasProperLetterCounts).ToArray();

        var wordsSet = words.ToHashSet();
        var prefixes = new HashSet<string>();

        foreach (var word in words)
        {
            for (var prefixLength = 1; prefixLength <= word.Length; prefixLength++)
            {
                prefixes.Add(word[..prefixLength]);
            }
        }

        var m = board.Length;
        var n = board[0].Length;
        var result = new HashSet<string>();

        var visited = new HashSet<(int i, int j)>();
        var deltas = new[] { (di: -1, dj: 0), (di: 1, dj: 0), (di: 0, dj: -1), (di: 0, dj: 1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                visited.Clear();
                GetWords(i, j, "");
            }
        }

        return result.ToArray();

        void GetWords(int i, int j, string prefix)
        {
            if (i < 0 || i >= m || j < 0 || j >= n)
            {
                return;
            }

            if (!visited.Add((i, j)))
            {
                return;
            }

            prefix += board[i][j];

            if (prefixes.Contains(prefix))
            {
                if (wordsSet.Contains(prefix))
                {
                    result.Add(prefix);

                    if (result.Count == words.Length)
                    {
                        return;
                    }
                }

                foreach (var (di, dj) in deltas)
                {
                    GetWords(i + di, j + dj, prefix);
                }
            }

            visited.Remove((i, j));
        }

        bool HasProperLetterCounts(string word)
        {
            foreach (var grouping in word.GroupBy(letter => letter))
            {
                var letter = grouping.Key;

                if (!letterCounts.ContainsKey(letter))
                {
                    return false;
                }

                var count = grouping.Count();

                if (letterCounts[letter] < count)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
