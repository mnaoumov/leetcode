using System.Collections;

namespace LeetCode.Problems._3654_Minimum_Sum_After_Divisible_Sum_Deletions;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution4 : ISolution
{
    public long MinArraySum(int[] nums, int k)
    {
        var prefixSumRemainderIndicesMap = Enumerable.Range(0, k).Select(_ => new List<int>()).ToArray();
        prefixSumRemainderIndicesMap[0].Add(-1);

        var n = nums.Length;

        var prefixSums = new long[n + 1];

        var prefixSum = 0;

        for (var i = 0; i < n; i++)
        {
            prefixSum += nums[i];
            prefixSumRemainderIndicesMap[prefixSum % k].Add(i);
            prefixSums[i + 1] = prefixSum;
        }

        var dp = new DynamicProgramming<HashableImmutableArray<Interval>, long>((intervals, recursiveFunc) =>
        {
            var ans = 0L;

            foreach (var interval in intervals)
            {
                ans += prefixSums[interval.To] - prefixSums[interval.From];
            }

            for (var r = 0; r < k; r++)
            {
                for (var i = 0; i < prefixSumRemainderIndicesMap[r].Count - 1; i++)
                {
                    for (var j = i + 1; j < prefixSumRemainderIndicesMap[r].Count; j++)
                    {
                        var index1 = prefixSumRemainderIndicesMap[r][i];
                        var index2 = prefixSumRemainderIndicesMap[r][j];

                        var newIntervals = new List<Interval>();

                        var isValidSplit = false;

                        foreach (var interval in intervals)
                        {
                            if (interval.To <= index1 + 1)
                            {
                                newIntervals.Add(interval);
                            }
                            else if (interval.From < index1 + 1)
                            {
                                newIntervals.Add(interval with { To = index1 + 1 });
                                isValidSplit = true;
                            }
                            else if (interval.To <= index2)
                            {
                                isValidSplit = true;
                            }
                            else if (interval.From < index2 + 1)
                            {
                                if (interval.To <= index2 + 1)
                                {
                                    continue;
                                }

                                newIntervals.Add(interval with { From = index2 + 1 });
                                isValidSplit = true;
                            }
                            else
                            {
                                newIntervals.Add(interval);
                            }
                        }

                        if (isValidSplit)
                        {
                            ans = Math.Min(ans, recursiveFunc(new HashableImmutableArray<Interval>(newIntervals)));
                        }
                    }
                }
            }

            return ans;
        });

        return dp.GetOrCalculate(new HashableImmutableArray<Interval>(new Interval(0, n)));
    }

    private record Interval(int From, int To);

    private class HashableImmutableArray<T> : IReadOnlyList<T>
    {
        private readonly T[] _items;

        public HashableImmutableArray(params T[] items) => _items = items.ToArray();
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

        public override string ToString() => string.Join(", ", _items);
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
