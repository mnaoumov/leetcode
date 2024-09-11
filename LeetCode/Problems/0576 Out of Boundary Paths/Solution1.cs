namespace LeetCode.Problems._0576_Out_of_Boundary_Paths;

/// <summary>
/// https://leetcode.com/submissions/detail/945217188/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
    {
        const int modulo = 1_000_000_007;

        var directions = new (int dRow, int dColumn)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        var dp = new DynamicProgramming<(int row, int column, int movesAvailable), int>((key, recursiveFunc) =>
        {
            var (row, column, movesAvailable) = key;

            var isOfBoundary = row < 0 || row >= m || column < 0 || column == n;

            if (isOfBoundary)
            {
                return 1;
            }

            if (movesAvailable == 0)
            {
                return 0;
            }

            var ans = 0;

            foreach (var (dRow, dColumn) in directions)
            {
                ans = (ans + recursiveFunc((row + dRow, column + dColumn, movesAvailable - 1))) % modulo;
            }

            return ans;
        });
        return dp.GetOrCalculate((startRow, startColumn, maxMove));
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
