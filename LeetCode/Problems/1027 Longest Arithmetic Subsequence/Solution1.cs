using JetBrains.Annotations;

namespace LeetCode.Problems._1027_Longest_Arithmetic_Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/920507726/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestArithSeqLength(int[] nums)
    {
        var n = nums.Length;

        var numIndicesMap = Enumerable.Range(0, n).GroupBy(index => nums[index]).ToDictionary(g => g.Key, g => g.OrderBy(index => index).ToArray());

        var dp = new DynamicProgramming<(int index, int diff), int>((key, recursiveFunc) =>
        {
            var (index, diff) = key;

            var num = nums[index];
            var nextNum = num + diff;
            var indices = numIndicesMap.GetValueOrDefault(nextNum, Array.Empty<int>());
            var indexOfIndices = Array.BinarySearch(indices, index + 1);

            if (indexOfIndices < 0)
            {
                indexOfIndices = ~indexOfIndices;
            }

            return indexOfIndices < indices.Length ? 1 + recursiveFunc((indices[indexOfIndices], diff)) : 1;
        });

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                result = Math.Max(result, 1 + dp.GetOrCalculate((j, nums[j] - nums[i])));
            }
        }

        return result;
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
