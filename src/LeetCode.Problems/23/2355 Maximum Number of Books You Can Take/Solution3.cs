namespace LeetCode.Problems._2355_Maximum_Number_of_Books_You_Can_Take;

/// <summary>
/// https://leetcode.com/problems/maximum-number-of-books-you-can-take/submissions/2134656865/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public long MaximumBooks(int[] books)
    {
        var n = books.Length;
        const int noIndex = -1;
        var previousIndices = new int[n];

        var monotoneStack = new Stack<int>();

        for (var i = 0; i < n; i++)
        {
            var diff = books[i] - i;

            while (monotoneStack.Count > 0)
            {
                var j = monotoneStack.Peek();
                var previousDiff = books[j] - j;

                if (previousDiff < diff)
                {
                    break;
                }

                monotoneStack.Pop();
            }

            previousIndices[i] = monotoneStack.TryPeek(out var previousIndex) ? previousIndex : noIndex;
            monotoneStack.Push(i);
        }
        
        var dp = new DynamicProgramming<int, long>((index, getOrCalculate) =>
        {
            if (index < 0)
            {
                return 0;
            }

            var previousIndex = previousIndices[index];

            var count = index - previousIndex;

            var b = books[index];

            if (count >= b)
            {
                return 1L * b * (b + 1) / 2;
            }

            return 1L * (2 * b - count + 1) * count / 2 + getOrCalculate(previousIndex);
        });

        return Enumerable.Range(0, n).Max(dp.GetOrCalculate);
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
