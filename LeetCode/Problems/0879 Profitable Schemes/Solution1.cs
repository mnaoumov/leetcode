using System.Numerics;

namespace LeetCode.Problems._0879_Profitable_Schemes;

/// <summary>
/// https://leetcode.com/submissions/detail/937631542/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int ProfitableSchemes(int n, int minProfit, int[] group, int[] profit)
    {
        const int modulo = 1_000_000_007;
        var crimeCount = group.Length;

        var dp = new DynamicProgramming<(int crimeIndex, int peopleAvailable, int requiredProfit), int>((key, recursiveFunc) =>
        {
            var (crimeIndex, peopleAvailable, requiredProfit) = key;

            if (requiredProfit <= 0)
            {
                return (int) BigInteger.ModPow(2, crimeCount - crimeIndex, modulo);
            }

            if (crimeIndex == crimeCount)
            {
                return 0;
            }

            var result = recursiveFunc((crimeIndex + 1, peopleAvailable, requiredProfit));

            if (group[crimeIndex] <= peopleAvailable)
            {
                result = (result + recursiveFunc((crimeIndex + 1, peopleAvailable - group[crimeIndex],
                    requiredProfit - profit[crimeIndex]))) % modulo;
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
