namespace LeetCode.Problems._0887_Super_Egg_Drop;

/// <summary>
/// https://leetcode.com/submissions/detail/947598310/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SuperEggDrop(int k, int n)
    {
        var dp = new DynamicProgramming<(int floorsCount, int eggsLeft), int>((key, recursiveFunc) =>
        {
            var (floorsCount, eggsLeft) = key;

            if (floorsCount <= 1)
            {
                return floorsCount;
            }

            if (eggsLeft == 1)
            {
                return floorsCount;
            }

            var low = 1;
            var high = floorsCount;

            while (low + 1 <= high)
            {
                var mid = low + (high - low >> 1);
                var eggBrokeAns = recursiveFunc((mid - 1, eggsLeft - 1));
                var eggDidNotBreakAns = recursiveFunc((floorsCount - mid, eggsLeft));

                if (eggBrokeAns < eggDidNotBreakAns)
                {
                    low = mid + 1;
                }
                else if (eggBrokeAns > eggDidNotBreakAns)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid;
                    high = mid;
                }
            }

            return 1 + Math.Min(
                Math.Max(
                    recursiveFunc((high - 1, eggsLeft - 1)),
                    recursiveFunc((floorsCount - high, eggsLeft))
                ),
                Math.Max(
                    recursiveFunc((low - 1, eggsLeft - 1)),
                    recursiveFunc((floorsCount - low, eggsLeft))
                )
            );
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
