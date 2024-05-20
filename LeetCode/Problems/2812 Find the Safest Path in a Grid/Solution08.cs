using JetBrains.Annotations;

namespace LeetCode.Problems._2812_Find_the_Safest_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1259284935/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution08 : ISolution
{
    public int MaximumSafenessFactor(IList<IList<int>> grid)
    {
        var n = grid.Count;
        const int thief = 1;

        if (grid[0][0] == thief || grid[n - 1][n - 1] == thief)
        {
            return 0;
        }

        var cellSafenessFactors = new int[n, n];
        var factorCellsMap = new Dictionary<int, List<(int row, int column)>>();
        InitCellSafenessFactors();

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

            foreach (var factor in factorCellsMap.Keys.Where(factor => factor >= safenessFactor))
            {
                foreach (var (row, column) in factorCellsMap[factor])
                {
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

        void InitCellSafenessFactors()
        {
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

            const int unset = -1;

            for (var row = 0; row < n; row++)
            {
                for (var column = 0; column < n; column++)
                {
                    cellSafenessFactors[row, column] = unset;
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

                    if (cellSafenessFactors[row, column] != unset)
                    {
                        continue;
                    }

                    cellSafenessFactors[row, column] = safenessFactor;
                    factorCellsMap.TryAdd(safenessFactor, new List<(int row, int column)>());
                    factorCellsMap[safenessFactor].Add((row, column));

                    foreach (var (dRow, dColumn) in deltas)
                    {
                        queue.Enqueue((row + dRow, column + dColumn));
                    }
                }

                safenessFactor++;
            }
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
