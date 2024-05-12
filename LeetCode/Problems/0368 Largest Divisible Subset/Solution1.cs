using JetBrains.Annotations;

namespace LeetCode.Problems._0368_Largest_Divisible_Subset;

/// <summary>
/// https://leetcode.com/submissions/detail/921084324/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IList<int> LargestDivisibleSubset(int[] nums)
    {
        Array.Sort(nums);
        var n = nums.Length;

        var dp = new DynamicProgramming<int, (int maxSubsetLength, int nextElementIndex)>(
            (index, recursiveFunc) =>
            {

                if (index == n)
                {
                    return (0, n);
                }

                var num = nums[index];

                var maxSubsetLength = 1;
                var nextElementIndex = n;

                for (var j = index + 1; j < n; j++)
                {
                    if (nums[j] % num != 0)
                    {
                        continue;
                    }

                    var maxSubsetLengthCandidate = 1 + recursiveFunc(j).maxSubsetLength;

                    if (maxSubsetLengthCandidate <= maxSubsetLength)
                    {
                        continue;
                    }

                    maxSubsetLength = maxSubsetLengthCandidate;
                    nextElementIndex = j;
                }

                return (maxSubsetLength, nextElementIndex);
            });

        var index = Enumerable.Range(0, n).MaxBy(index => dp.GetOrCalculate(index).maxSubsetLength);

        var result = new List<int>();

        while (index < n)
        {
            result.Add(nums[index]);
            index = dp.GetOrCalculate(index).nextElementIndex;
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
