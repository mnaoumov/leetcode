namespace LeetCode.Problems._1014_Best_Sightseeing_Pair;

/// <summary>
/// https://leetcode.com/submissions/detail/926928274/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxScoreSightseeingPair(int[] values)
    {
        var n = values.Length;
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
            index == n ? int.MinValue : Math.Max(values[index] - index, recursiveFunc(index + 1)));
        return Enumerable.Range(0, n - 1).Max(i => values[i] + i + dp.GetOrCalculate(i + 1));
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
