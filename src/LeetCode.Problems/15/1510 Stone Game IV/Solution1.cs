namespace LeetCode.Problems._1510_Stone_Game_IV;

/// <summary>
/// https://leetcode.com/submissions/detail/958657548/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool WinnerSquareGame(int n)
    {
        var dp = new DynamicProgramming<int, bool>((m, recursiveFunc) =>
        {
            if (m == 0)
            {
                return false;
            }

            var sqrt = (int) Math.Sqrt(m);
            return Enumerable.Range(1, sqrt).Any(k => !recursiveFunc(m - k * k));
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
