using JetBrains.Annotations;

namespace LeetCode._0651_4_Keys_Keyboard;

/// <summary>
/// https://leetcode.com/submissions/detail/924014604/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxA(int n)
    {
        var dp = new DynamicProgramming<(int keyPressesLeft, int bufferSize, int totalSize), int>((key, recursiveFunc) =>
        {
            var (keyPressesLeft, bufferSize, printedCount) = key;

            if (keyPressesLeft == 0)
            {
                return 0;
            }

            var typeOrPasteSize = Math.Max(1, bufferSize);
            var result = typeOrPasteSize + recursiveFunc((keyPressesLeft - 1, bufferSize, printedCount + typeOrPasteSize));

            if (keyPressesLeft >= 2)
            {
                result = Math.Max(result, recursiveFunc((keyPressesLeft - 2, printedCount, printedCount)));
            }

            return result;
        });

        return dp.GetOrCalculate((n, 0, 0));
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
