using JetBrains.Annotations;

namespace LeetCode.Problems._0837_New_21_Game;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public double New21Game(int n, int k, int maxPts)
    {
        var dp = new DynamicProgramming<int, double>((points, recursiveFunc) =>
        {
            if (points > n)
            {
                return 0;
            }

            if (points >= k)
            {
                return n - points + 1;
            }

            return recursiveFunc(points + 1) +
                   (recursiveFunc(points + 1) - recursiveFunc(points + maxPts + 1)) / maxPts;
        });

        return dp.GetOrCalculate(0) - dp.GetOrCalculate(1);
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
