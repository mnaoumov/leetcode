using JetBrains.Annotations;

namespace LeetCode._0887_Super_Egg_Drop;

/// <summary>
/// https://leetcode.com/submissions/detail/947562146/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int SuperEggDrop(int k, int n)
    {
        var dp = new DynamicProgramming<(int floorsCount, int eggsLeft), int>((key, recursiveFunc) =>
        {
            var (floorsCount, eggsLeft) = key;

            if (floorsCount == 0)
            {
                return 0;
            }

            if (eggsLeft == 1)
            {
                return floorsCount;
            }

            var ans = int.MaxValue;

            for (var i = 1; i <= floorsCount; i++)
            {
                ans = Math.Min(ans,
                    Math.Max(1 + recursiveFunc((i - 1, eggsLeft - 1)), 1 + recursiveFunc((floorsCount - i, eggsLeft))));
            }

            return ans;
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
