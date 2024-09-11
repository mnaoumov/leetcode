namespace LeetCode.Problems._0718_Maximum_Length_of_Repeated_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/898740397/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        var dp = new DynamicProgramming<(int index1, int index2), int>((key, recursiveFunc) =>
        {
            var (index1, index2) = key;

            if (index1 >= nums1.Length || index2 >= nums2.Length)
            {
                return 0;
            }

            var commonLength = 0;

            while (index1 + commonLength < nums1.Length && index2 + commonLength < nums2.Length &&
                   nums1[index1 + commonLength] == nums2[index2 + commonLength])
            {
                commonLength++;
            }

            return new[]
            {
                commonLength,
                recursiveFunc((index1 + 1, index2)),
                recursiveFunc((index1, index2 + 1))
            }.Max();
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
