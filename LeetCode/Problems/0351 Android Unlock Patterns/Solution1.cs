namespace LeetCode.Problems._0351_Android_Unlock_Patterns;

/// <summary>
/// https://leetcode.com/submissions/detail/954660687/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfPatterns(int m, int n)
    {
        var middleKeyMap = new Dictionary<(int min, int max), int>
        {
            [(1, 3)] = 2,
            [(1, 7)] = 4,
            [(1, 9)] = 5,
            [(2, 8)] = 5,
            [(3, 7)] = 5,
            [(3, 9)] = 6,
            [(4, 6)] = 5,
            [(7, 9)] = 8
        };

        var dp = new DynamicProgramming<(int maxKeysCount, int lastKey, int usedKeysMask), int>((dpKey, recursiveFunc) =>
        {
            var (maxKeysCount, lastKey, usedKeysMask) = dpKey;

            if (maxKeysCount == 0)
            {
                return 0;
            }

            var ans = 0;

            for (var key = 1; key <= 9; key++)
            {
                if (IsUsed(key))
                {
                    continue;
                }

                var pathKey = lastKey < key
                    ? (min: lastKey, max: key)
                    : (min: key, max: lastKey);

                if (middleKeyMap.TryGetValue(pathKey, out var middleKey) && !IsUsed(middleKey))
                {
                    continue;
                }

                ans += 1 + recursiveFunc((maxKeysCount - 1, key, usedKeysMask | 1 << key));
            }

            return ans;

            bool IsUsed(int key2) => (usedKeysMask & 1 << key2) != 0;
        });

        return dp.GetOrCalculate((n, 0, 0)) - dp.GetOrCalculate((m - 1, 0, 0));
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
