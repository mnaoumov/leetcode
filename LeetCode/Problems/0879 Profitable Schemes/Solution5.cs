using System.Numerics;
using JetBrains.Annotations;

namespace LeetCode.Problems._0879_Profitable_Schemes;

/// <summary>
/// https://leetcode.com/submissions/detail/937646734/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        const int modulo = 1_000_000_007;

        var crimes = group.Zip(profit, (peopleRequired, profitAmount) => (peopleRequired, profitAmount))
            .OrderBy(c => c.peopleRequired).ToArray();

        var crimeCount = crimes.Length;

        var totalPeopleRequiredSuffixes = new long[crimeCount + 1];

        for (var i = crimeCount - 1; i >= 0; i--)
        {
            totalPeopleRequiredSuffixes[i] = totalPeopleRequiredSuffixes[i + 1] + crimes[i].peopleRequired;
        }

        var dp = new DynamicProgramming<(int minCrimeIndex, int peopleUsed, int gainedProfit), int>((key, recursiveFunc) =>
        {
            var (minCrimeIndex, peopleUsed, gainedProfit) = key;

            if (gainedProfit == minProfit && peopleUsed + totalPeopleRequiredSuffixes[minCrimeIndex] <= n)
            {
                return (int) BigInteger.ModPow(2, crimeCount - minCrimeIndex, modulo) - (minCrimeIndex == 0 ? 1 : 0);
            }

            var result = gainedProfit == minProfit ? 1 : 0;

            for (var crimeIndex = minCrimeIndex; crimeIndex < crimeCount; crimeIndex++)
            {
                var (peopleRequired, profitAmount) = crimes[crimeIndex];

                if (peopleUsed + peopleRequired > n)
                {
                    break;
                }

                result = (result + recursiveFunc((crimeIndex + 1, peopleUsed + peopleRequired,
                    Math.Min(minProfit, gainedProfit + profitAmount)))) % modulo;
            }

            return result;
        });

        return dp.GetOrCalculate((0, 0, 0));
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
