using JetBrains.Annotations;

namespace LeetCode._3041_Maximize_Consecutive_Elements_in_an_Array_After_Modification;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-124/submissions/detail/1177961680/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxSelectedElements(int[] nums)
    {
        Array.Sort(nums);
        var dp = new DynamicProgramming<(int index, int previousValue, int previousSequenceLength), int>((key, recursiveFunc) =>
        {
            var (index, previousValue, previousSequenceLength) = key;

            if (index == nums.Length)
            {
                return previousSequenceLength;
            }

            var ans = previousSequenceLength;

            ans = Math.Max(ans, recursiveFunc((index + 1, nums[index], 1)));
            ans = Math.Max(ans, recursiveFunc((index + 1, nums[index] + 1, 1)));

            if (index > 0)
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, previousValue, previousSequenceLength)));
            }

            if (index > 0 && (nums[index] == previousValue + 1 || nums[index] == previousValue))
            {
                ans = Math.Max(ans, recursiveFunc((index + 1, previousValue + 1, previousSequenceLength + 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
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
