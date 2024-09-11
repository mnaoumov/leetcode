using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2812_Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-357/submissions/detail/1013490825/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution03 : ISolution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        var n = grid.Count;

        var thieves = new List<(int r, int c)>();

        for (var r = 0; r < n; r++)
        {
            for (var c = 0; c < n; c++)
            {
                if (grid[r][c] == 1)
                {
                    thieves.Add((r, c));
                }
            }
        }

        var safenessFactors = new int[n, n];
        var maxPathSafenessFactors = new Dictionary<(int r, int c), int>();

        for (var r = 0; r < n; r++)
        {
            for (var c = 0; c < n; c++)
            {
                safenessFactors[r, c] = thieves.Min(thief => Math.Abs(r - thief.r) + Math.Abs(c - thief.c));
                maxPathSafenessFactors[(r, c)] = 0;
            }
        }

        var queue = new Queue<(int r, int c, int pathSafenessFactor)>();
        queue.Enqueue((0, 0, int.MaxValue));

        var directions = new (int dr, int dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while (queue.Count > 0)
        {
            var (r, c, pathSafenessFactor) = queue.Dequeue();
            pathSafenessFactor = Math.Min(pathSafenessFactor, safenessFactors[r, c]);

            if (maxPathSafenessFactors[(r, c)] >= pathSafenessFactor)
            {
                continue;
            }

            maxPathSafenessFactors[(r, c)] = pathSafenessFactor;

            if (pathSafenessFactor <= maxPathSafenessFactors[(n - 1, n - 1)])
            {
                continue;
            }

            foreach (var (dr, dc) in directions)
            {
                var nextR = r + dr;
                var nextC = c + dc;

                if (nextR < 0 || nextR >= n || nextC < 0 || nextC >= n)
                {
                    continue;
                }

                if (maxPathSafenessFactors[(nextR, nextC)] >= pathSafenessFactor)
                {
                    continue;
                }

                queue.Enqueue((nextR, nextC, pathSafenessFactor));
            }
        }

        return maxPathSafenessFactors[(n - 1, n - 1)];
    }
}
