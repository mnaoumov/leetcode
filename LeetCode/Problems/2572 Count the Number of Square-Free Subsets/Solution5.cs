using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2572_Count_the_Number_of_Square_Free_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/901269797/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int SquareFreeSubsets(int[] nums)
    {
        const int modulo = 1_000_000_007;
        var primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        var numbersDivisibleBySquares = new HashSet<int>();
        var factorsMap = new Dictionary<int, HashSet<int>>();

        foreach (var num in nums)
        {
            if (numbersDivisibleBySquares.Contains(num))
            {
                continue;
            }

            if (factorsMap.ContainsKey(num))
            {
                continue;
            }

            var temp = num;
            var factors = new HashSet<int>();

            foreach (var prime in primes)
            {
                if (temp == 1)
                {
                    break;
                }

                if (temp % prime != 0)
                {
                    continue;
                }

                factors.Add(prime);
                temp /= prime;

                if (temp % prime != 0)
                {
                    continue;
                }

                numbersDivisibleBySquares.Add(num);
                break;
            }

            if (temp == 1)
            {
                factorsMap[num] = factors;
            }
        }

        var factorsSetDp = new DynamicProgramming<string, HashSet<int>>((primeFactorsStr, _) =>
            primeFactorsStr
                .Split(',', StringSplitOptions.RemoveEmptyEntries).Select(str => Convert.ToInt32(str))
                .ToHashSet());

        var dp = new DynamicProgramming<(int index, string setPrimeFactorsStr), int>((key, recursiveFunc) =>
        {
            var (index, setPrimeFactorsStr) = key;
            var setPrimeFactors = factorsSetDp.GetOrCalculate(setPrimeFactorsStr);

            if (index == nums.Length)
            {
                return 0;
            }

            for (var i = index; i < nums.Length; i++)
            {
                var num = nums[i];

                if (numbersDivisibleBySquares.Contains(num))
                {
                    continue;
                }

                var numPrimeFactors = factorsMap[num];

                if (numPrimeFactors.Overlaps(setPrimeFactors))
                {
                    continue;
                }

                var joinedPrimeFactorsStr =
                    string.Join(',', setPrimeFactors.Concat(numPrimeFactors).OrderBy(factor => factor));

                return (1 + recursiveFunc((i + 1, joinedPrimeFactorsStr)) + recursiveFunc((i + 1, setPrimeFactorsStr))) % modulo;
            }

            return 0;
        });

        var squareFreeSubsets = dp.GetOrCalculate((0, ""));
        return squareFreeSubsets;
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
