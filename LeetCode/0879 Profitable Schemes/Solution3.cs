using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode._0879_Profitable_Schemes;

/// <summary>
/// https://leetcode.com/submissions/detail/937641163/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        const int modulo = 1_000_000_007;

        var crimes = group.Zip(profit, (peopleRequired, profitAmount) => (peopleRequired, profitAmount))
            .OrderBy(c => c.peopleRequired).ToArray();

        var crimeCount = crimes.Length;

        var totalPeopleRequiredSuffixes = new long[crimeCount];

        for (var i = crimeCount - 1; i >= 0; i--)
        {
            totalPeopleRequiredSuffixes[i] = (i < crimeCount - 1 ? totalPeopleRequiredSuffixes[i + 1] : 0) +
                                             crimes[i].peopleRequired;
        }

        var dp = new DynamicProgramming<(int minCrimeIndex, int peopleAvailable, int requiredProfit), int>((key, recursiveFunc) =>
        {
            var (minCrimeIndex, peopleAvailable, requiredProfit) = key;

            if (peopleAvailable >= totalPeopleRequiredSuffixes[minCrimeIndex])
            {
                return (int) BigInteger.ModPow(2, crimeCount - minCrimeIndex, modulo) - (minCrimeIndex == 0 ? 1 : 0);
            }

            var result = requiredProfit <= 0 ? 1 : 0;

            for (var crimeIndex = minCrimeIndex; crimeIndex < crimeCount; crimeIndex++)
            {
                var (peopleRequired, profitAmount) = crimes[crimeIndex];

                if (peopleRequired > peopleAvailable)
                {
                    break;
                }

                result = (result + recursiveFunc((crimeIndex + 1, peopleAvailable - peopleRequired,
                    Math.Max(0, requiredProfit - profitAmount)))) % modulo;
            }

            return result;
        });

        return dp.GetOrCalculate((0, n, minProfit));
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
