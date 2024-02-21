using JetBrains.Annotations;

namespace LeetCode._1642_Furthest_Building_You_Can_Reach;

/// <summary>
/// https://leetcode.com/submissions/detail/1178355349/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int FurthestBuilding(int[] heights, int bricks, int ladders)
    {
        var dp = new DynamicProgramming<(int index, int bricksLeft, int laddersLeft), int>((key, recursiveFunc) =>
        {
            var (index, bricksLeft, laddersLeft) = key;

            if (index == heights.Length - 1)
            {
                return 0;
            }

            if (heights[index] >= heights[index + 1])
            {
                return 1 + recursiveFunc((index + 1, bricksLeft, laddersLeft));
            }

            var ans = 0;

            var heightDiff = heights[index + 1] - heights[index];

            if (heightDiff <= bricksLeft)
            {
                ans = 1 + recursiveFunc((index + 1, bricksLeft - heightDiff, laddersLeft));
            }

            if (laddersLeft > 0)
            {
                ans = Math.Max(ans, 1 + recursiveFunc((index + 1, bricksLeft, laddersLeft - 1)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, bricks, ladders));
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
