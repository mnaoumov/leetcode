using JetBrains.Annotations;

namespace LeetCode._0279_Perfect_Squares;

/// <summary>
/// https://leetcode.com/problems/perfect-squares/submissions/847729726/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int NumSquares(int n)
    {
        var dp = new DynamicProgramming<int, int>((key, recursiveFunc) =>
        {
            var sqrt = (int) Math.Floor(Math.Sqrt(key));

            if (sqrt * sqrt == key)
            {
                return 1;
            }

            return 1 + Enumerable.Range(1, sqrt).Select(m => recursiveFunc(key - m * m)).Min();
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
