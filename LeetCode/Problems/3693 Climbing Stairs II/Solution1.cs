namespace LeetCode.Problems._3693_Climbing_Stairs_II;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-166/problems/climbing-stairs-ii/submissions/1784293652/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ClimbStairs(int n, int[] costs)
    {
        var dp = new DynamicProgramming<int, int>((index, getOrCalculate) =>
        {
            if (index == n)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var j = index + 1; j <= Math.Min(index + 3, n); j++)
            {
                ans = Math.Min(ans, costs[j - 1] + (j - index) * (j - index) + getOrCalculate(j));
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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
