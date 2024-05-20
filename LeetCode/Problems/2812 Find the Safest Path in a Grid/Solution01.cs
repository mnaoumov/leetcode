using JetBrains.Annotations;

namespace LeetCode.Problems._2812_Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-357/submissions/detail/1013458067/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution01 : ISolution
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

        var directions = new (int dr, int dc)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var low = 0;
        var high = 2 * n;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (ExistsPathWithSafenessFactor(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool ExistsPathWithSafenessFactor(int safenessFactor)
        {
            var seen = new HashSet<(int r, int c)>();

            return Dfs(0, 0);

            bool Dfs(int r, int c)
            {
                if (r < 0 || c < 0 || r >= n || c >= n)
                {
                    return false;
                }

                seen.Add((r, c));

                if (!thieves.All(thief => Math.Abs(r - thief.r) + Math.Abs(c - thief.c) >= safenessFactor))
                {
                    return false;
                }

                if (r == n - 1 && c == n - 1)
                {
                    return true;
                }

                foreach (var (dr, dc) in directions)
                {
                    var nextR = r + dr;
                    var nextC = c + dc;

                    if (!seen.Contains((nextR, nextC)) && Dfs(nextR, nextC))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
