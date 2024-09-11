using System.Collections;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3229_Minimum_Operations_to_Make_Array_Equal_to_Target;

/// <summary>
/// TODO
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public long MinimumOperations(int[] nums, int[] target)
    {
        var diffs = nums.Zip(target, (num, targetNum) => targetNum - num).ToArray();
        var dp = new DynamicProgramming<HashableImmutableArray<int>, long>((arr, recursiveFunc) =>
        {
            switch (arr.Count)
            {
                case 0:
                    return 0;
                case 1:
                    return Math.Abs(arr[0]);
            }

            if (arr[0] == 0)
            {
                return recursiveFunc(new HashableImmutableArray<int>(arr.Skip(1)));
            }

            var lowerBound = arr.Select(Math.Abs).Max();

            var nextArr = arr.ToArray();
            var sign = Math.Sign(arr[0]);

            var ans = long.MaxValue;

            for (var i = 0; i < arr.Count; i++)
            {
                nextArr[i] -= sign;
                var nextLowerBound = nextArr.Select(Math.Abs).Max();

                if (nextLowerBound >= ans - 1)
                {
                    continue;
                }

                ans = Math.Min(ans, 1 + recursiveFunc(new HashableImmutableArray<int>(nextArr)));

                if (ans == lowerBound)
                {
                    break;
                }
            }

            return ans;
        });

        return dp.GetOrCalculate(new HashableImmutableArray<int>(diffs));
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
