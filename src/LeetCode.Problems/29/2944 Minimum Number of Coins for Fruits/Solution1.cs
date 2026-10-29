namespace LeetCode.Problems._2944_Minimum_Number_of_Coins_for_Fruits;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-118/submissions/detail/1106117407/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumCoins(int[] prices)
    {
        var dp = new DynamicProgramming<(int index, int freeCount), int>((key, recursiveFunc) =>
        {
            var (index, freeCount) = key;

            if (index == prices.Length)
            {
                return 0;
            }

            var ans = prices[index] + recursiveFunc((index + 1, index + 1));

            if (freeCount > 0)
            {
                ans = Math.Min(ans, recursiveFunc((index + 1, freeCount - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
