namespace LeetCode.Problems._3290_Maximum_Multiplication_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-415/submissions/detail/1390501782/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxScore(int[] a, int[] b)
    {
        var dp = new DynamicProgramming<(int aIndex, int bIndex), long>((key, recursiveFunc) =>
        {
            var (aIndex, bIndex) = key;

            if (aIndex == a.Length)
            {
                return 0L;
            }

            var ans = long.MinValue;

            if (a.Length - aIndex < b.Length - bIndex)
            {
                ans = recursiveFunc((aIndex, bIndex + 1));
            }

            ans = Math.Max(ans, 1L * a[aIndex] * b[bIndex] + recursiveFunc((aIndex + 1, bIndex + 1)));
            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
