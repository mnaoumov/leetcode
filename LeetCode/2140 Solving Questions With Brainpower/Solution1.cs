using JetBrains.Annotations;

namespace LeetCode._2140_Solving_Questions_With_Brainpower;

/// <summary>
/// https://leetcode.com/submissions/detail/919788298/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MostPoints(int[][] questions)
    {
        var dp = new DynamicProgramming<int, long>((index, recursiveFunc) =>
            index >= questions.Length
                ? 0
                : Math.Max(recursiveFunc(index + 1), questions[index][0] + recursiveFunc(index + questions[index][1] + 1)));
        return dp.GetOrCalculate(0);
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
