namespace LeetCode.Problems._3603_Minimum_Cost_Path_with_Alternating_Directions_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-160/problems/minimum-cost-path-with-alternating-directions-ii/submissions/1687379213/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinCost(int m, int n, int[][] waitCost)
    {
        var dp = new DynamicProgramming<(int row, int column), long>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            var ans = long.MaxValue;
            var entryCost = 1L * (row + 1) * (column + 1);

            if (row == m - 1 && column == n - 1)
            {
                return entryCost;
            }

            if (row < m - 1)
            {
                ans = Math.Min(ans, entryCost + recursiveFunc((row + 1, column)));
            }

            if (column < n - 1)
            {
                ans = Math.Min(ans, entryCost + recursiveFunc((row, column + 1)));
            }

            if (row != 0 || column != 0)
            {
                ans += waitCost[row][column];
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
