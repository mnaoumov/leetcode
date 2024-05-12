using JetBrains.Annotations;

namespace LeetCode.Problems._1035_Uncrossed_Lines;

/// <summary>
/// https://leetcode.com/submissions/detail/919937688/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxUncrossedLines(int[] nums1, int[] nums2)
    {
        var numIndicesMap2 = Enumerable.Range(0, nums2.Length).GroupBy(index2 => nums2[index2])
            .ToDictionary(g => g.Key, g => g.OrderBy(index2 => index2).ToArray());

        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 == nums1.Length || index2 == nums2.Length)
            {
                return 0;
            }

            var indices2 = numIndicesMap2.GetValueOrDefault(nums1[index1], Array.Empty<int>());
            var indexOfIndices2 = Array.BinarySearch(indices2, index2);

            if (indexOfIndices2 < 0)
            {
                indexOfIndices2 = ~indexOfIndices2;
            }

            return indices2.Skip(indexOfIndices2).Select(nextIndex2 => 1 + recursiveFunc((index1 + 1, nextIndex2 + 1))).Prepend(recursiveFunc((index1 + 1, index2))).Max();
        });

        return dp.GetOrCalculate((0, 0));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
