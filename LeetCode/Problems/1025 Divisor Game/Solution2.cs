namespace LeetCode.Problems._1025_Divisor_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/926853020/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool DivisorGame(int n)
    {
        var dp = new DynamicProgramming<int, bool>((number, recursiveFunc) =>
            number != 1 && Enumerable.Range(1, number - 1).Where(x => number % x == 0)
                .Any(x => !recursiveFunc(number - x)));

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
