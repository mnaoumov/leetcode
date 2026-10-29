namespace LeetCode.Problems._3363_Find_the_Maximum_Number_of_Fruits_Collected;

/// <summary>
/// https://leetcode.com/problems/find-the-maximum-number-of-fruits-collected/submissions/1727421237/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        var ans = 0;

        var n = fruits.Length;

        for (var i = 0; i < n; i++)
        {
            ans += fruits[i][i];
        }

        var dp = new DynamicProgramming<(int row, int column, bool shouldTranspose), int>((key, recursiveFunc) =>
        {
            var (row, column, shouldTranspose) = key;

            var fruit = shouldTranspose ? fruits[column][row] : fruits[row][column];

            if (row == n - 2)
            {
                return fruit;
            }

            var ans2 = int.MinValue;

            for (var newColumn = column - 1; newColumn <= column + 1; newColumn++)
            {
                if (newColumn >= n || newColumn <= row + 1)
                {
                    continue;
                }

                ans2 = Math.Max(ans2, fruit + recursiveFunc((row + 1, newColumn, shouldTranspose)));
            }

            return ans2;
        });

        ans += dp.GetOrCalculate((0, n - 1, false));
        ans += dp.GetOrCalculate((0, n - 1, true));

        return ans;
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