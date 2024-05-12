using JetBrains.Annotations;

namespace LeetCode._2915_Length_of_the_Longest_Subsequence_That_Sums_to_Target;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-116/submissions/detail/1086099637/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LengthOfLongestSubsequence(IList<int> nums, int target)
    {
        nums = nums.OrderBy(num => num).ToArray();
        const int impossible = -1;

        var dp = new DynamicProgramming<(int index, int sum), int>((key, recursiveFunc) =>
        {
            var (index, sum) = key;

            if (sum == 0)
            {
                return 0;
            }

            if (index == nums.Count)
            {
                return impossible;
            }

            var num = nums[index];

            if (num > sum)
            {
                return impossible;
            }

            var ans = recursiveFunc((index + 1, sum));
            var next = recursiveFunc((index + 1, sum - num));

            if (next != impossible)
            {
                ans = Math.Max(ans, 1 + next);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, target));
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
