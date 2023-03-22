using JetBrains.Annotations;

namespace LeetCode._0746_Min_Cost_Climbing_Stairs;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCostClimbingStairs(int[] cost)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index >= cost.Length)
            {
                return 0;
            }

            var stepCost = index == -1 ? 0 : cost[index];

            return stepCost + Math.Min(recursiveFunc(index + 1), recursiveFunc(index + 2));
        });

        return dp.GetOrCalculate(-1);
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
