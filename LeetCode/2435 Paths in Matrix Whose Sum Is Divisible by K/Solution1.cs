using JetBrains.Annotations;

namespace LeetCode._2435_Paths_in_Matrix_Whose_Sum_Is_Divisible_by_K;

/// <summary>
/// https://leetcode.com/submissions/detail/882140678/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int NumberOfPaths(int[][] grid, int k)
    {
        const int modulo = 1_000_000_007;

        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new DynamicProgramming<(int row, int column, int remainder), int>((key, recursiveFunc) =>
        {
            var (row, column, remainder) = key;

            if (row == m || column == n)
            {
                return 0;
            }

            var nextRemainder = (k + remainder - grid[row][column]) % k;

            if (row == m - 1 && column == n - 1)
            {
                return nextRemainder == 0 ? 1 : 0;
            }

            return (recursiveFunc((row + 1, column, nextRemainder)) + recursiveFunc((row, column + 1, nextRemainder))) %
                   modulo;
        });

        return dp.GetOrCalculate((0, 0, 0));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
