using JetBrains.Annotations;

namespace LeetCode.Problems._1402_Reducing_Dishes;

/// <summary>
/// https://leetcode.com/submissions/detail/923966227/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSatisfaction(int[] satisfaction)
    {
        Array.Sort(satisfaction);

        var dp = new DynamicProgramming<(int index, int time), int>((key, recursiveFunc) =>
        {
            var (index, time) = key;

            if (index == satisfaction.Length)
            {
                return 0;
            }

            return Math.Max(
                recursiveFunc((index + 1, time)),
                time * satisfaction[index] + recursiveFunc((index + 1, time + 1)));
        });

        return dp.GetOrCalculate((0, 1));
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
