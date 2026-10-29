namespace LeetCode.Problems._3882_Minimum_XOR_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/minimum-xor-path-in-a-grid/submissions/2183519791/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinCost(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new DynamicProgramming<(int row, int column), SortedSet<int>>((key, getOrCalculate) =>
        {
            var (row, column) = key;

            var value = grid[row][column];

            if (row == 0 && column == 0)
            {
                return new SortedSet<int> { value };
            }

            var set = new SortedSet<int>();

            if (row > 0)
            {
                foreach (var upValue in getOrCalculate((row - 1, column)))
                {
                    set.Add(upValue ^ value);
                }
            }

            if (column > 0)
            {
                foreach (var leftValue in getOrCalculate((row, column - 1)))
                {
                    set.Add(leftValue ^ value);
                }
            }

            return set;
        });

        return dp.GetOrCalculate((m - 1, n - 1)).Min;
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
