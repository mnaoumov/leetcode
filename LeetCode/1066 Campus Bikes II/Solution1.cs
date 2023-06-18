using JetBrains.Annotations;

namespace LeetCode._1066_Campus_Bikes_II;

/// <summary>
/// https://leetcode.com/submissions/detail/974344113/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int AssignBikes(int[][] workers, int[][] bikes)
    {
        var n = workers.Length;
        var m = bikes.Length;

        var dp = new DynamicProgramming<(int workerIndex, int bikeMask), int>((key, recursiveFunc) =>
        {
            var (workerIndex, bikeMask) = key;

            if (workerIndex == n)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var bikeIndex = 0; bikeIndex < m; bikeIndex++)
            {
                if ((bikeMask & 1 << bikeIndex) != 0)
                {
                    continue;
                }

                ans = Math.Min(ans,
                    Distance(workers[workerIndex], bikes[bikeIndex]) +
                    recursiveFunc((workerIndex + 1, bikeMask | 1 << bikeIndex)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
    }

    private static int Distance(IReadOnlyList<int> point1, IReadOnlyList<int> point2) =>
        Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);

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
