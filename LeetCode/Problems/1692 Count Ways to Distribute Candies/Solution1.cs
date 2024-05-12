using JetBrains.Annotations;

namespace LeetCode._1692_Count_Ways_to_Distribute_Candies;

/// <summary>
/// https://leetcode.com/submissions/detail/956052746/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WaysToDistribute(int n, int k)
    {
        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<(int candiesCount, int bagsCount), int>((key, recursiveFunc) =>
        {
            var (candiesCount, bagsCount) = key;

            if (candiesCount == 0)
            {
                return bagsCount == 0 ? 1 : 0;
            }

            return (int) ((recursiveFunc((candiesCount - 1, bagsCount - 1)) +
                           1L * bagsCount * recursiveFunc((candiesCount - 1, bagsCount))) % modulo);
        });

        return dp.GetOrCalculate((n, k));
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
