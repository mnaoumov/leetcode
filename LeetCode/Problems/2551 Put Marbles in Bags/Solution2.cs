using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2551_Put_Marbles_in_Bags;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-330/submissions/detail/887192141/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long PutMarbles(int[] weights, int k)
    {
        var max = weights.Max();

        var dp = new DynamicProgramming<(int index, int bagsCount, bool isMin), long>((key, recursiveFunc) =>
        {
            var (index, bagsCount, isMin) = key;

            if (bagsCount == 1)
            {
                return weights[index] + weights[^1];
            }

            var result = isMin ? long.MaxValue : long.MinValue;

            for (var i = index; i <= weights.Length - bagsCount; i++)
            {
                var bagCost = weights[index] + weights[i];

                switch (isMin)
                {
                    case true when result <= bagCost - (bagsCount - 1):
                    case false when result >= bagCost + 2L * max * (bagsCount - 1):
                        continue;
                }

                var nextBestCost = recursiveFunc((i + 1, bagsCount - 1, isMin));
                var totalCost = bagCost + nextBestCost;
                result = isMin ? Math.Min(result, totalCost) : Math.Max(result, totalCost);
            }

            return result;
        });

        return dp.GetOrCalculate((0, k, false)) - dp.GetOrCalculate((0, k, true));
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
