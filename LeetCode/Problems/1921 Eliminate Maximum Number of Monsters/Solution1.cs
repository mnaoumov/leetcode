using JetBrains.Annotations;
using System.Collections;
using LeetCode.Base;

namespace LeetCode.Problems._1921_Eliminate_Maximum_Number_of_Monsters;

/// <summary>
/// https://leetcode.com/submissions/detail/1093404436/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int EliminateMaximum(int[] dist, int[] speed)
    {
        var n = dist.Length;

        var dp = new DynamicProgramming<(int time, HashableImmutableArray<int> eliminatedMonsters), int>((key, recursiveFunc) =>
        {
            var (time, eliminatedMonsters) = key;

            if (eliminatedMonsters.Count == n)
            {
                return 0;
            }

            var eliminatedMonstersSet = new SortedSet<int>(eliminatedMonsters);

            for (var i = 0; i < n; i++)
            {
                if (eliminatedMonstersSet.Contains(i))
                {
                    continue;
                }

                if (dist[i] - time * speed[i] <= 0)
                {
                    return 0;
                }
            }

            var ans = 0;

            for (var i = 0; i < n; i++)
            {
                if (eliminatedMonstersSet.Contains(i))
                {
                    continue;
                }

                if (dist[i] - time * speed[i] <= 0)
                {
                    return 0;
                }

                eliminatedMonstersSet.Add(i);
                ans = Math.Max(ans,
                    1 + recursiveFunc((time + 1, new HashableImmutableArray<int>(eliminatedMonstersSet))));
                eliminatedMonstersSet.Remove(i);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, new HashableImmutableArray<int>()));
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

        public HashableImmutableArray() : this(Enumerable.Empty<T>())
        {
        }

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
