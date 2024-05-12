using JetBrains.Annotations;

namespace LeetCode.Problems._1884_Egg_Drop_With_2_Eggs_and_N_Floors;

/// <summary>
/// https://leetcode.com/submissions/detail/947558973/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int TwoEggDrop(int n)
    {
        var dp = new DynamicProgramming<int, int>((floors, recursiveFunc) =>
        {
            if (floors == 0)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var i = 1; i <= floors; i++)
            {
                ans = Math.Min(ans, Math.Max(1 + recursiveFunc(floors - i), i));
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
