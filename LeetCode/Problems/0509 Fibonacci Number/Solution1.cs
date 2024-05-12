using JetBrains.Annotations;

namespace LeetCode.Problems._0509_Fibonacci_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/923843687/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int Fib(int n)
    {
        var dp = new DynamicProgramming<int, int>((k, recursiveFunc) =>
            k <= 1 ? k : recursiveFunc(k - 1) + recursiveFunc(k - 2));
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
