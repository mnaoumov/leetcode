using JetBrains.Annotations;

namespace LeetCode.Problems._0417_Pacific_Atlantic_Water_Flow;

/// <summary>
/// https://leetcode.com/submissions/detail/925218308/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var m = heights.Length;
        var n = heights[0].Length;

        var entries = new Dictionary<(int i, int j), (bool hasExitToPacificOcean, bool hasExitToAtlanticOcean)>();

        var goodEntry = (hasExitToPacificOcean: true, hasExitToAtlanticOcean: true);

        var result = new List<IList<int>>();
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (!entries.TryGetValue((i, j), out var entry))
                {
                    entry = Dfs(i, j);
                }

                if (entry == goodEntry)
                {
                    result.Add(new[] { i, j });
                }
            }
        }

        return result;

        (bool hasExitToPacificOcean, bool hasExitToAtlanticOcean) Dfs(int i, int j)
        {
            if (entries.TryGetValue((i, j), out var entry))
            {
                return entry;
            }

            entries[(i, j)] = entry = (hasExitToPacificOcean: i == 0 || j == 0,
                hasExitToAtlanticOcean: i == m - 1 || j == n - 1);

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                if (heights[i][j] < heights[nextI][nextJ])
                {
                    continue;
                }

                var (hasExitToPacificOcean, hasExitToAtlanticOcean) = Dfs(i + di, j + dj);
                entry.hasExitToPacificOcean |= hasExitToPacificOcean;
                entry.hasExitToAtlanticOcean |= hasExitToAtlanticOcean;
            }

            entries[(i, j)] = entry;
            return entry;
        }
    }
}
