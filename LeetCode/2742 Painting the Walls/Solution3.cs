using JetBrains.Annotations;

namespace LeetCode._2742_Painting_the_Walls;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int PaintWalls(int[] cost, int[] time)
    {
        var n = cost.Length;

        var dp = new DynamicProgramming<(string unpaintedWallIndicesStr, int freePainterTime), int>((key, recursiveFunc) =>
        {
            var (unpaintedWallIndicesStr, freePainterTime) = key;
            var unpaintedWallIndices = new SortedSet<int>(unpaintedWallIndicesStr.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            if (unpaintedWallIndices.Count <= freePainterTime)
            {
                return 0;
            }

            var ans = int.MaxValue;

            var unpaintedWallIndicesCopy = unpaintedWallIndices.ToArray();

            foreach (var paidPainterWallIndex in unpaintedWallIndicesCopy)
            {
                var paidPainterCost = cost[paidPainterWallIndex];
                unpaintedWallIndices.Remove(paidPainterWallIndex);
                ans = Math.Min(ans,
                    paidPainterCost + recursiveFunc((string.Join(',', unpaintedWallIndices),
                        freePainterTime + time[paidPainterWallIndex])));
                unpaintedWallIndices.Add(paidPainterWallIndex);
            }

            return ans;
        });

        return dp.GetOrCalculate((string.Join(',', Enumerable.Range(0, n)), 0));
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
