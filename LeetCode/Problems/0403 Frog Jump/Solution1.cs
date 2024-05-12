using JetBrains.Annotations;

namespace LeetCode._0403_Frog_Jump;

/// <summary>
/// https://leetcode.com/submissions/detail/1032682123/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool CanCross(int[] stones)
    {
        var stonesSet = stones.ToHashSet();

        var dp = new DynamicProgramming<(int stone, int lastJumpUnits), bool>((key, recursiveFunc) =>
        {
            var (stone, lastJump) = key;

            if (!stonesSet.Contains(stone))
            {
                return false;
            }

            if (stone == stones[^1])
            {
                return true;
            }

            return Jump(lastJump - 1) || Jump(lastJump) || Jump(lastJump + 1);

            bool Jump(int units) => units > 0 && recursiveFunc((stone + units, units));
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
