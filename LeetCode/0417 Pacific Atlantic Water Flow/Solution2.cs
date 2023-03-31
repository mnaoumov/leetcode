using JetBrains.Annotations;

namespace LeetCode._0417_Pacific_Atlantic_Water_Flow;

/// <summary>
/// https://leetcode.com/submissions/detail/925230462/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var m = heights.Length;
        var n = heights[0].Length;

        var result = new List<IList<int>>();
        var pacificOceanDirections = new[] { (-1, 0), (0, -1) };
        var atlanticOceanDirections = new[] { (1, 0), (0, 1) };
        var hasExitToPacificOceanMap = new Dictionary<(int i, int j), bool>();
        var hasExitToAtlanticOceanMap = new Dictionary<(int i, int j), bool>();

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (!hasExitToPacificOceanMap.TryGetValue((i, j), out var hasExitToPacificOcean))
                {
                    hasExitToPacificOcean = Dfs(i, j, true);
                }

                if (!hasExitToAtlanticOceanMap.TryGetValue((i, j), out var hasExitToAtlanticOcean))
                {
                    hasExitToAtlanticOcean = Dfs(i, j, false);
                }

                if (hasExitToPacificOcean && hasExitToAtlanticOcean)
                {
                    result.Add(new[] { i, j });
                }
            }
        }

        return result;

        bool Dfs(int i, int j, bool isPacificOcean)
        {
            var map = isPacificOcean ? hasExitToPacificOceanMap : hasExitToAtlanticOceanMap;
            var directions = isPacificOcean ? pacificOceanDirections : atlanticOceanDirections;

            if (map.TryGetValue((i, j), out var hasExit))
            {
                return hasExit;
            }

            hasExit = isPacificOcean ? i == 0 || j == 0 : i == m - 1 || j == n - 1;

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

                hasExit |= Dfs(nextI, nextJ, isPacificOcean);
            }

            map[(i, j)] = hasExit;
            return hasExit;
        }
    }
}
