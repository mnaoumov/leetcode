using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0417_Pacific_Atlantic_Water_Flow;

/// <summary>
/// https://leetcode.com/submissions/detail/925428108/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public IList<IList<int>> PacificAtlantic(int[][] heights)
    {
        var m = heights.Length;
        var n = heights[0].Length;

        var result = new List<IList<int>>();
        var hasExitMap = new Dictionary<(int i, int j, Ocean ocean), bool>();
        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (HasExit(i, j, Ocean.Pacific) && HasExit(i, j, Ocean.Atlantic))
                {
                    result.Add(new[] { i, j });
                }
            }
        }

        return result;

        bool HasExit(int i, int j, Ocean ocean)
        {
            var seen = new bool[m, n];
            return (bool) Dfs(i, j)!;

            bool? Dfs(int i2, int j2)
            {
                if (hasExitMap.TryGetValue((i2, j2, ocean), out var hasExit))
                {
                    return hasExit;
                }

                if (seen[i2, j2])
                {
                    return null;
                }

                seen[i2, j2] = true;

                if (ocean == Ocean.Pacific
                        ? i2 == 0 || j2 == 0
                        : i2 == m - 1 || j2 == n - 1)
                {
                    hasExitMap[(i2, j2, ocean)] = true;
                    return true;
                }

                foreach (var (di, dj) in directions)
                {
                    var nextI = i2 + di;
                    var nextJ = j2 + dj;

                    if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                    {
                        continue;
                    }

                    if (heights[i2][j2] < heights[nextI][nextJ])
                    {
                        continue;
                    }

                    if (Dfs(nextI, nextJ) != true)
                    {
                        continue;
                    }

                    hasExitMap[(i2, j2, ocean)] = true;
                    return true;
                }

                hasExitMap[(i2, j2, ocean)] = false;
                return false;
            }
        }
    }

    private enum Ocean
    {
        Pacific,
        Atlantic
    }
}
