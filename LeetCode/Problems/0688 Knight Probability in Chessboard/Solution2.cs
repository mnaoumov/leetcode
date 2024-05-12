using JetBrains.Annotations;

namespace LeetCode.Problems._0688_Knight_Probability_in_Chessboard;

/// <summary>
/// https://leetcode.com/submissions/detail/954669139/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public double KnightProbability(int n, int k, int row, int column)
    {
        var directions = new (int dRow, int dColumn)[]
        {
            (1, 2),
            (1, -2),
            (2, 1),
            (2, -1),
            (-1, 2),
            (-1, -2),
            (-2, 1),
            (-2, -1)
        };

        var dp = new DynamicProgramming<(int row, int column, int movesLeft), double>((key, recursiveFunc) =>
        {
            var (row2, column2, movesLeft) = key;

            if (row2 < 0 || column2 < 0 || row2 >= n || column2 >= n)
            {
                return 0;
            }

            if (movesLeft == 0)
            {
                return 1;
            }

            var ans = 0d;

            foreach (var (dRow, dColumn) in directions)
            {
                ans += 0.125 * recursiveFunc((row2 + dRow, column2 + dColumn, movesLeft - 1));
            }

            return ans;
        });

        return dp.GetOrCalculate((row, column, k));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
