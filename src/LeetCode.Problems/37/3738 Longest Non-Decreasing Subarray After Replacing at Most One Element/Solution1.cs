namespace LeetCode.Problems._3738_Longest_Non_Decreasing_Subarray_After_Replacing_at_Most_One_Element;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-169/problems/longest-non-decreasing-subarray-after-replacing-at-most-one-element/submissions/1824252722/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestSubarray(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, bool canReplace, bool canReplaceFirst), (int length, int replacedFirst)>((key, getOrCalculate) =>
        {
            var (index, canReplace, canReplaceFirst) = key;
            var num = nums[index];
            var ans = (length: 1, replacedFirst: num);

            if (index == n - 1)
            {
                return ans;
            }

            var nextNum = nums[index + 1];

            var next = getOrCalculate((index + 1, canReplace, canReplaceFirst));

            if (num <= next.replacedFirst)
            {
                return (next.length + 1, num);
            }

            if (num <= nextNum)
            {
                next = getOrCalculate((index + 1, canReplace, false));

                if (next.length + 1 > ans.length)
                {
                    ans = (next.length + 1, num);
                }
            }
            else if (canReplace)
            {
                if (ans.length < 2)
                {
                    ans = (2, num);
                }

                if (index + 2 < n)
                {
                    next = getOrCalculate((index + 2, false, false));

                    if (next.length + 2 > ans.length && num <= nums[index + 2])
                    {
                        ans = (next.length + 2, num);
                    }
                }
            }

            if (!canReplaceFirst)
            {
                return ans;
            }

            next = getOrCalculate((index + 1, false, false));

            if (next.length + 1 > ans.length)
            {
                ans = (next.length + 1, nextNum);
            }

            return ans;
        });

        return Enumerable.Range(0, n).Select(i => dp.GetOrCalculate((i, true, true)).length).Max();
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
