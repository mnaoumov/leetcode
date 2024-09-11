namespace LeetCode.Problems._0600_Non_negative_Integers_without_Consecutive_Ones;

/// <summary>
/// https://leetcode.com/submissions/detail/1073021674/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindIntegers(int n)
    {
        var dp = new DynamicProgramming<int, int>((n2, recursiveFunc) =>
        {
            if (n2 == 0)
            {
                return 1;
            }

            return recursiveFunc(n2 / 2) + recursiveFunc((n2 - 1) / 4);
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
