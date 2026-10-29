namespace LeetCode.Problems._3857_Minimum_Cost_to_Split_into_Ones;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-491/problems/minimum-cost-to-split-into-ones/submissions/1934213542/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int n)
    {
        var dp = new DynamicProgramming<int, int>((m, getOrCalculate) =>
        {
            if (m == 1)
            {
                return 0;
            }

            var k = m / 2;
            var l = m - k;
            return k * l + getOrCalculate(k) + getOrCalculate(l);
        });

        return dp.GetOrCalculate(n);
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
