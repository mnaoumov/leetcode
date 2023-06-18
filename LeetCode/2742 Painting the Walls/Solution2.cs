using JetBrains.Annotations;

namespace LeetCode._2742_Painting_the_Walls;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-350/submissions/detail/973747005/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int PaintWalls(int[] cost, int[] time)
    {
        var n = cost.Length;
        var expensiveIndices = Enumerable.Range(0, n).OrderByDescending(i => cost[i]).ToArray();

        var dp = new DynamicProgramming<string, int>((paintedWallIndicesStr, recursiveFunc) =>
        {
            var paintedWallIndices = new SortedSet<int>(paintedWallIndicesStr.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            if (paintedWallIndices.Count == n)
            {
                return 0;
            }

            var ans = 0;

            var paidPainterWallIndex = -1;

            for (var i = n - 1; i >= 0; i--)
            {
                paidPainterWallIndex = expensiveIndices[i];
                if (paintedWallIndices.Contains(paidPainterWallIndex))
                {
                    continue;
                }

                ans = cost[paidPainterWallIndex];
                paintedWallIndices.Add(paidPainterWallIndex);
                break;
            }

            var paidPainterTimeLeft = time[paidPainterWallIndex];

            foreach (var freePainterWallIndex in expensiveIndices)
            {
                if (freePainterWallIndex == paidPainterWallIndex)
                {
                    break;
                }

                if (paintedWallIndices.Contains(freePainterWallIndex))
                {
                    continue;
                }

                paintedWallIndices.Add(freePainterWallIndex);
                paidPainterTimeLeft--;

                if (paidPainterTimeLeft == 0)
                {
                    break;
                }
            }

            var nextPaintedWallIndicesStr = string.Join(',', paintedWallIndices);
            return ans + recursiveFunc(nextPaintedWallIndicesStr);
        });

        return dp.GetOrCalculate("");
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
