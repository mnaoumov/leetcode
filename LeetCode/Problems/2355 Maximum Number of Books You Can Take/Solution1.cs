using JetBrains.Annotations;

namespace LeetCode._2355_Maximum_Number_of_Books_You_Can_Take;

/// <summary>
/// https://leetcode.com/submissions/detail/1077993676/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaximumBooks(int[] books)
    {
        var n = books.Length;
        var dp = new DynamicProgramming<(int l, int previousShelfBookCount), long>((key, recursiveFunc) =>
        {
            var (l, previousShelfBookCount) = key;

            if (l == n)
            {
                return 0;
            }

            if (books[l] <= previousShelfBookCount && previousShelfBookCount > 0)
            {
                return 0;
            }

            var ans = previousShelfBookCount == 0 ? recursiveFunc((l + 1, 0)) : 0;

            for (var i = previousShelfBookCount + 1; i <= books[l]; i++)
            {
                ans = Math.Max(ans, i + recursiveFunc((l + 1, i)));
            }

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
