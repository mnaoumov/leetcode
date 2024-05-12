using JetBrains.Annotations;

namespace LeetCode.Problems._0634_Find_the_Derangement_of_An_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/954824723/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int FindDerangement(int n)
    {
        const int modulo = 1_000_000_007;

        var factDp = new DynamicProgramming<int, int>((m, recursiveFunc) =>
        {
            if (m == 1)
            {
                return 1;
            }

            return (int) (1L * m * recursiveFunc(m - 1) % modulo);
        });

        var combinatorialDp = new DynamicProgramming<(int m, int k), int>((key, recursiveFunc) =>
        {
            var (m, k) = key;

            if (k == 0)
            {
                return 1;
            }

            if (m == 0)
            {
                return 0;
            }

            return (recursiveFunc((m - 1, k)) + recursiveFunc((m - 1, k - 1))) % modulo;
        });

        var dp = new DynamicProgramming<int, int>((m, recursiveFunc) =>
        {
            if (m == 0)
            {
                return 1;
            }

            var ans = factDp.GetOrCalculate(m);

            for (var k = 0; k < m; k++)
            {
                ans -= (int) (1L * recursiveFunc(k) * combinatorialDp.GetOrCalculate((m, k)) % modulo);
                ans = (ans + modulo) % modulo;
            }

            return ans;
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
