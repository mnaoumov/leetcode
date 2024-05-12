using JetBrains.Annotations;

namespace LeetCode.Problems._0741_Cherry_Pickup;

/// <summary>
/// https://leetcode.com/submissions/detail/954162211/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CherryPickup(int[][] grid)
    {
        const int thorn = -1;
        const int cherry = 1;
        const int impossible = -1;

        var n = grid.Length;

        if (n == 1)
        {
            return grid[0][0] == cherry ? 1 : 0;
        }

        var dp = new DynamicProgramming<(int row1, int column1, int row2), int>((key, recursiveFunc) =>
        {
            var (row1, column1, row2) = key;
            var column2 = row1 + column1 - row2;

            if (!IsValid(row1) || !IsValid(row2) || !IsValid(column1) || !IsValid(column2) || grid[row1][column1] == thorn || grid[row2][column2] == thorn)
            {
                return impossible;
            }

            if (row1 == n - 1 && column1 == n - 1)
            {
                return grid[n - 1][n - 1];
            }

            var next = new[]
            {
                recursiveFunc((row1 + 1, column1, row2)),
                recursiveFunc((row1 + 1, column1, row2 + 1)),
                recursiveFunc((row1, column1 + 1, row2)),
                recursiveFunc((row1, column1 + 1, row2 + 1))
            }.Max();

            if (next == impossible)
            {
                return impossible;
            }

            var ans = grid[row1][column1];

            if (row2 != row1)
            {
                ans += grid[row2][column2];
            }

            return ans + next;
        });

        var ans2 = dp.GetOrCalculate((0, 0, 0));
        return ans2 == impossible ? 0 : ans2;

        bool IsValid(int index) => 0 <= index && index < n;
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
