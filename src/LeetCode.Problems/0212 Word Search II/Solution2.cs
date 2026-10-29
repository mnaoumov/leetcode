namespace LeetCode.Problems._0212_Word_Search_II;

/// <summary>
/// https://leetcode.com/problems/word-search-ii/submissions/837069605/
/// https://leetcode.com/problems/word-search-ii/submissions/837087027/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public IList<string> FindWords(char[][] board, string[] words)
    {
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
                foreach (var word in GetWords(i, j, ""))
                {
                    result.Add(word);
                }
            }
        }

        return result.ToArray();

        IEnumerable<string> GetWords(int i, int j, string prefix)
        {
            if (i < 0 || i >= m || j < 0 || j >= n)
            {
                yield break;
            }

            if (!visited.Add((i, j)))
            {
                yield break;
            }

            prefix += board[i][j];

            if (prefixes.Contains(prefix))
            {
                if (wordsSet.Contains(prefix))
                {
                    yield return prefix;
                }

                foreach (var (di, dj) in deltas)
                {
                    foreach (var word in GetWords(i + di, j + dj, prefix))
                    {
                        yield return word;
                    }
                }
            }

            visited.Remove((i, j));
        }
    }
}
