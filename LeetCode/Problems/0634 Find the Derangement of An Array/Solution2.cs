using JetBrains.Annotations;

namespace LeetCode.Problems._0634_Find_the_Derangement_of_An_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/954828167/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindDerangement(int n)
    {
        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<int, int>((m, recursiveFunc) =>
        {
            return m switch
            {
                0 => 1,
                1 => 0,
                _ => (int) (1L * (m - 1) * (recursiveFunc(m - 2) + recursiveFunc(m - 1)) % modulo)
            };
        });

        return dp.GetOrCalculate(n);
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
