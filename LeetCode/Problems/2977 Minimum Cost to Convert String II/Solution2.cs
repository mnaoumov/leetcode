using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2977_Minimum_Cost_to_Convert_String_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1127129696/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinimumCost(string source, string target, string[] original, string[] changed, int[] cost)
    {
        var parts = original.Concat(changed).Distinct().ToArray();
        var m = parts.Length;
        var partToIndexMap = Enumerable.Range(0, m).ToDictionary(i => parts[i]);

        const long impossibleCost = long.MaxValue;
        var costs = new long[m, m];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < m; j++)
            {
                costs[i, j] = impossibleCost;
            }

            costs[i, i] = 0;
        }

        var originalSet = original.ToHashSet();
        var changedSet = changed.ToHashSet();

        var n = original.Length;

        for (var k = 0; k < n; k++)
        {
            var fromIndex = partToIndexMap[original[k]];
            var toIndex = partToIndexMap[changed[k]];
            var changeCost = cost[k];

            if (costs[fromIndex, toIndex] <= changeCost)
            {
                continue;
            }

            costs[fromIndex, toIndex] = changeCost;

            for (var i = 0; i < m; i++)
            {
                if (costs[i, fromIndex] == impossibleCost)
                {
                    continue;
                }

                for (var j = 0; j < m; j++)
                {
                    if (costs[toIndex, j] == impossibleCost)
                    {
                        continue;
                    }

                    var newCost = costs[i, fromIndex] + costs[fromIndex, toIndex] +
                                  costs[toIndex, j];

                    if (costs[i, j] > newCost)
                    {
                        costs[i, j] = newCost;
                    }
                }
            }
        }

        var dp = new DynamicProgramming<int, long>((index, recursiveFunc) =>
        {
            if (index == source.Length)
            {
                return 0;
            }

            var ans = impossibleCost;

            if (source[index] == target[index])
            {
                ans = recursiveFunc(index + 1);
            }

            for (var j = index + 1; j <= source.Length; j++)
            {
                var originalStr = source[index..j];

                if (!originalSet.Contains(originalStr))
                {
                    continue;
                }

                var changedStr = target[index..j];

                if (!changedSet.Contains(changedStr))
                {
                    continue;
                }

                var changeCost = costs[partToIndexMap[originalStr], partToIndexMap[changedStr]];

                if (changeCost == impossibleCost)
                {
                    continue;
                }

                var nextCost = recursiveFunc(j);

                if (nextCost == impossibleCost)
                {
                    continue;
                }

                ans = Math.Min(ans, changeCost + nextCost);
            }

            return ans;
        });

        var ans2 = dp.GetOrCalculate(0);
        return ans2 == impossibleCost ? -1 : ans2;
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
