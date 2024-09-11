namespace LeetCode.Problems._1493_Longest_Subarray_of_1_s_After_Deleting_One_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/987230854/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSubarray(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, bool shouldDelete), (int prefixLength, int maxLength)>((key, recursiveFunc) =>
        {
            var (index, shouldDelete) = key;

            if (index == nums.Length)
            {
                return (0, 0);
            }

            var prefixLength = 0;

            for (var i = index; i < n; i++)
            {
                if (nums[i] == 0)
                {
                    break;
                }

                prefixLength++;
            }

            if (prefixLength == n - index)
            {
                var length = prefixLength - (shouldDelete ? 1 : 0);
                return (length, length);
            }

            var maxLength = Math.Max(prefixLength, recursiveFunc((index + prefixLength + 1, shouldDelete)).maxLength);

            if (shouldDelete)
            {
                maxLength = Math.Max(maxLength,
                    prefixLength + recursiveFunc((index + prefixLength + 1, false)).prefixLength);
            }

            return (prefixLength, maxLength);
        });

        return dp.GetOrCalculate((0, true)).maxLength;
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
