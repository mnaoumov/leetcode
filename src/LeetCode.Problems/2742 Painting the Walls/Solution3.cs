namespace LeetCode.Problems._2742_Painting_the_Walls;

/// <summary>
/// https://leetcode.com/submissions/detail/974160317/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int PaintWalls(int[] cost, int[] time)
    {
        var n = cost.Length;
        
        var dp = new DynamicProgramming<(int index, int freePainterTime), int>((key, recursiveFunc) =>
        {
            var (index, paintedCount) = key;

            if (paintedCount >= n)
            {
                return 0;
            }

            if (index == n)
            {
                return int.MaxValue;
            }

            var ans = recursiveFunc((index + 1, paintedCount));

            var next = recursiveFunc((index + 1, paintedCount + time[index] + 1));

            if (next < int.MaxValue)
            {
                ans = Math.Min(ans, cost[index] + next);
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
