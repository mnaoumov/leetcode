using JetBrains.Annotations;

namespace LeetCode._0790_Domino_and_Tromino_Tiling;

/// <summary>
/// https://leetcode.com/submissions/detail/864533369/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumTilings(int n)
    {
        var dp = new DynamicProgramming<int, int>((size, recursiveFunc) =>
        {
            switch (size)
            {
                case 0 or 1:
                    return 1;
                case 2:
                    return 2;
                default:
                {
                    var result = recursiveFunc(size - 1) + recursiveFunc(size - 2) + 2 * Enumerable.Range(0, size - 2)
                        .Select(subSize => (long) recursiveFunc(subSize)).Sum();
                    return (int) (result % 1_000_000_007);
                }
            }
        });

        return dp.GetOrCalculate(n);
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
