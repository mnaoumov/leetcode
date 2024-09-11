namespace LeetCode.Problems._1218_Longest_Arithmetic_Subsequence_of_Given_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/919902621/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestSubsequence(int[] arr, int difference)
    {
        var valueIndicesMap = Enumerable.Range(0, arr.Length).GroupBy(index => arr[index]).ToDictionary(g => g.Key, g => g.OrderBy(index => index).ToArray());

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var indices = valueIndicesMap.GetValueOrDefault(arr[index] + difference, Array.Empty<int>());
            var indexOfIndices = Array.BinarySearch(indices, index + 1);

            if (indexOfIndices < 0)
            {
                indexOfIndices = ~indexOfIndices;
            }

            return indices.Skip(indexOfIndices).Select(nextIndex => 1 + recursiveFunc(nextIndex)).Prepend(1).Max();
        });

        return Enumerable.Range(0, arr.Length).Max(i => dp.GetOrCalculate(i));
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
