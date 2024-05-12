using System.Collections;
using JetBrains.Annotations;

namespace LeetCode._3077_Maximum_Strength_of_K_Disjoint_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-388/submissions/detail/1199177239/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MaximumStrength(int[] nums, int k)
    {
        var n = nums.Length;
        const long impossible = long.MinValue;

        var dp = new DynamicProgramming<(int index, HashableImmutableArray<int> unusedResultIndices), long>((key, recursiveFunc) =>
        {
            var (index, unusedResultIndices) = key;

            if (unusedResultIndices.Count == 0)
            {
                return 0;
            }

            if (n - index < unusedResultIndices.Count)
            {
                return impossible;
            }

            var nextUnusedResultIndicesMap = new Dictionary<int, HashableImmutableArray<int>>();

            foreach (var resultIndex in unusedResultIndices)
            {
                nextUnusedResultIndicesMap[resultIndex] = new HashableImmutableArray<int>(unusedResultIndices.Except(new[] { resultIndex }));
            }

            var ans = recursiveFunc((index + 1, unusedResultIndices));

            var sum = 0L;

            for (var j = index; j <= n - unusedResultIndices.Count; j++)
            {
                sum += nums[j];

                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var resultIndex in unusedResultIndices)
                {
                    var nextResult = recursiveFunc((j + 1, nextUnusedResultIndicesMap[resultIndex]));

                    if (nextResult != impossible)
                    {
                        ans = Math.Max(ans, sum * (k - resultIndex + 1) * (resultIndex % 2 == 1 ? 1 : -1) + nextResult);
                    }
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, new HashableImmutableArray<int>(Enumerable.Range(1, k))));
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
