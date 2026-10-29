namespace LeetCode.Problems._3840_House_Robber_V;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-176/problems/house-robber-v/submissions/1919040829/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long Rob(int[] nums, int[] colors)
    {
        const int noRobbedColor = 0;
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int previousColor), long>((key, getOrCalculate) =>
        {
            var (index, previousColor) = key;

            if (index == n)
            {
                return 0;
            }

            var ans = getOrCalculate((index + 1, noRobbedColor));

            var currentColor = colors[index];

            if (currentColor != previousColor)
            {
                ans = Math.Max(ans, nums[index] + getOrCalculate((index + 1, currentColor)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, noRobbedColor));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
