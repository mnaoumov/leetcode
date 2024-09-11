namespace LeetCode.Problems._3122_Minimum_Number_of_Operations_to_Satisfy_Conditions;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-394/submissions/detail/1237823739/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOperations(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        const int digitsCount = 10;
        var counts = new int[n, digitsCount];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                counts[j, grid[i][j]]++;
            }
        }

        const int bigNumber = -1;

        var dp = new DynamicProgramming<(int columnIndex, int previousColumnNumber), int>((key, recursiveFunc) =>
        {
            var (columnIndex, previousColumnNumber) = key;

            if (columnIndex == n)
            {
                return 0;
            }

            var ans = m + recursiveFunc((columnIndex + 1, bigNumber));

            for (var columnNumber = 0; columnNumber < digitsCount; columnNumber++)
            {
                if (columnNumber == previousColumnNumber)
                {
                    continue;
                }

                ans = Math.Min(ans,
                    m - counts[columnIndex, columnNumber] + recursiveFunc((columnIndex + 1, columnNumber)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, bigNumber));
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
