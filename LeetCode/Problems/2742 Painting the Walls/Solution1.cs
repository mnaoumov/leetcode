using JetBrains.Annotations;

namespace LeetCode.Problems._2742_Painting_the_Walls;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-350/submissions/detail/973725361/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int PaintWalls(int[] cost, int[] time)
    {
        var n = cost.Length;

        var dp = new DynamicProgramming<(int paidPainterTimeLeft, string paintedWallIndicesStr), int>((key, recursiveFunc) =>
        {
            var (paidPainterTimeLeft, paintedWallIndicesStr) = key;

            var paintedWallIndices = new SortedSet<int>(paintedWallIndicesStr.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            if (paintedWallIndices.Count == n)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var i = 0; i < n; i++)
            {
                if (!paintedWallIndices.Add(i))
                {
                    continue;
                }

                var nextPaintedWallIndicesStr = string.Join(',', paintedWallIndices);
                paintedWallIndices.Remove(i);

                ans = Math.Min(ans,
                    paidPainterTimeLeft == 0
                        ? cost[i] + recursiveFunc((time[i], nextPaintedWallIndicesStr))
                        : recursiveFunc((paidPainterTimeLeft - 1, nextPaintedWallIndicesStr)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, ""));
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
