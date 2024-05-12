using System.Collections;
using JetBrains.Annotations;

namespace LeetCode.Problems._2931_Maximum_Spending_After_Buying_Items;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-117/submissions/detail/1096653457/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxSpending(int[][] values)
    {
        var m = values.Length;
        var n = values[0].Length;

        var dp = new DynamicProgramming<HashableImmutableArray<int>, long>((usedProductIndices, recursiveFunc) =>
        {
            var day = 1 + m * n - usedProductIndices.Sum(index => index);

            var nextUsedProductIndices = usedProductIndices.ToArray();

            var ans = 0L;

            for (var i = 0; i < m; i++)
            {
                if (nextUsedProductIndices[i] == 0)
                {
                    continue;
                }

                nextUsedProductIndices[i]--;
                ans = Math.Max(ans,
                    values[i][nextUsedProductIndices[i]] * day +
                    recursiveFunc(new HashableImmutableArray<int>(nextUsedProductIndices))
                );
                nextUsedProductIndices[i]++;
            }

            return ans;
        });

        return dp.GetOrCalculate(new HashableImmutableArray<int>(Enumerable.Repeat(n, m)));
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

    private class HashableImmutableArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _items;
        public HashableImmutableArray(IEnumerable<T> items) => _items = items.ToArray();

        public override int GetHashCode() => (_items as IStructuralEquatable).GetHashCode(EqualityComparer<T>.Default);

        public override bool Equals(object? obj) =>
            ReferenceEquals(this, obj) ||
            obj is HashableImmutableArray<T> other && _items.SequenceEqual(other._items);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        // ReSharper disable once NotDisposedResourceIsReturned
        public IEnumerator<T> GetEnumerator() => _items.AsEnumerable().GetEnumerator();
        public int Count => _items.Length;
        public T this[int index] => _items[index];
    }
}
