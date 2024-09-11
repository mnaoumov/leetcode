namespace LeetCode.Problems._2355_Maximum_Number_of_Books_You_Can_Take;

/// <summary>
/// https://leetcode.com/submissions/detail/1078018639/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaximumBooks(int[] books)
    {
        var n = books.Length;
        var dp = new DynamicProgramming<int, long>((r, recursiveFunc) =>
        {
            if (r < 0)
            {
                return 0;
            }

            var ans = 0L + books[r];
            var maxTakeCount = books[r];

            for (var i = r - 1; i >= 0; i--)
            {
                maxTakeCount--;

                if (maxTakeCount <= 0)
                {
                    break;
                }

                if (books[i] > maxTakeCount)
                {
                    ans += maxTakeCount;
                }
                else
                {
                    return ans + recursiveFunc(i);
                }
            }

            return ans;
        });

        return Enumerable.Range(0, n).Max(r => dp.GetOrCalculate(r));
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
