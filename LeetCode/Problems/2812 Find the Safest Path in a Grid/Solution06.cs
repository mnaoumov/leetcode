namespace LeetCode.Problems._2812_Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1259273918/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution06 : ISolution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        var n = grid.Count;

        var cellSafenessFactors = InitCellSafenessFactors();

        var low = 0;
        var high = n - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (IsSafe(mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;

        bool IsSafe(int safenessFactor)
        {
            var uf = new UnionFind<(int row, int column)>();

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    if (cellSafenessFactors[row, column] < safenessFactor)
                    {
                        continue;
                    }

                    if (row + 1 < n && cellSafenessFactors[row + 1, column] >= safenessFactor)
                    {
                        uf.Union((row, column), (row + 1, column));
                    }

                    if (column + 1 < n && cellSafenessFactors[row, column + 1] >= safenessFactor)
                    {
                        uf.Union((row, column), (row, column + 1));
                    }
                }
            }

            return uf.Connected((0, 0), (n - 1, n - 1));
        }

        int[,] InitCellSafenessFactors()
        {
            const int thief = 1;

            var deltas = new[]
            {
                (1, 0), (-1, 0), (0, 1), (0, -1)
            };

            var queue = new Queue<(int row, int column)>();

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    if (grid[row][column] == thief)
                    {
                        queue.Enqueue((row, column));
                    }
                }
            }

            var ans = new int[n, n];
            const int unset = -1;

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    ans[row, column] = unset;
                }
            }

            var safenessFactor = 0;

            while (queue.Count > 0)
            {
                var count = queue.Count;

                for (var i = 0; i < count; i++)
                {
                    var (row, column) = queue.Dequeue();

                    if (row < 0 || row >= n || column < 0 || column >= n)
                    {
                        continue;
                    }

                    if (ans[row, column] != unset)
                    {
                        continue;
                    }

                    ans[row, column] = safenessFactor;

                    foreach (var (dRow, dColumn) in deltas)
                    {
                        queue.Enqueue((row + dRow, column + dColumn));
                    }
                }

                safenessFactor++;
            }

            return ans;
        }
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        private T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

        public void Union(T x, T y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.Equals(rootY))
            {
                return;
            }

            var rankX = GetRank(rootX);
            var rankY = GetRank(rootY);

            if (rankX < rankY)
            {
                _roots[rootX] = rootY;
            }
            else if (rankX > rankY)
            {
                _roots[rootY] = rootX;
            }
            else
            {
                _roots[rootX] = rootY;
                _ranks[rootY] = rankY + 1;
            }
        }

        private int GetRank(T x) => _ranks.GetValueOrDefault(x, 1);

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
