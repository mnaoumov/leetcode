using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2830_Maximize_the_Profit_as_the_Salesman;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-359/submissions/detail/1026313426/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MaximizeTheProfit(int n, IList<IList<int>> offers)
    {
        var offerObjs = offers
            .Select(offer => (start: offer[0], end: offer[1], gold: offer[2]))
            .OrderBy(offer => offer.start)
            .ThenBy(offer => offer.end)
            .ToArray();

        var m = offerObjs.Length;
        var nextIndices = Enumerable.Repeat(m, m).ToArray();

        for (var i = 0; i < m; i++)
        {
            var low = i + 1;
            var high = m - 1;

            while (low <= high)
            {
                var mid = low + (high - low >> 1);

                if (offerObjs[mid].start <= offerObjs[i].end)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            nextIndices[i] = low;
        }

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            var ans = 0;

            for (var k = index; k < m; k++)
            {
                ans = Math.Max(ans, offerObjs[k].gold + recursiveFunc(nextIndices[k]));
            }

            return ans;
        });

        return dp.GetOrCalculate(0);
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
