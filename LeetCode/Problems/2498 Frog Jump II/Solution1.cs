using JetBrains.Annotations;

namespace LeetCode.Problems._2498_Frog_Jump_II;

/// <summary>
/// https://leetcode.com/submissions/detail/858356153/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxJump(int[] stones)
    {
        var n = stones.Length;

        var dp = new DynamicProgramming<int, (int minimumCost, int lastReturnStone)>((index, recursiveFunc) =>
        {
            if (index == n - 1)
            {
                return (0, n - 1);
            }

            var minimumCost2 = int.MaxValue;
            var lastReturnStone2 = -1;
            var returnCost = 0;

            for (var i = index + 1; i < n; i++)
            {
                var (minimumCost3, lastReturnStone3) = recursiveFunc(i);

                var cost = new[]
                {
                    stones[i] - stones[index],
                    minimumCost3,
                    stones[lastReturnStone3] - stones[i - 1],
                    returnCost
                }.Max();

                if (cost <= minimumCost2)
                {
                    minimumCost2 = cost;
                    lastReturnStone2 = i == index + 1 ? lastReturnStone3 : index + 1;
                }

                returnCost = Math.Max(returnCost, stones[i] - stones[i - 1]);
            }

            return (minimumCost2, lastReturnStone2);
        });

        var (minimumCost, _) = dp.GetOrCalculate(0);
        return minimumCost;
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
