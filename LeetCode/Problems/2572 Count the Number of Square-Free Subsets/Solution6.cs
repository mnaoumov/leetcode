using JetBrains.Annotations;

namespace LeetCode.Problems._2572_Count_the_Number_of_Square_Free_Subsets;

/// <summary>
/// https://leetcode.com/submissions/detail/901614275/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int SquareFreeSubsets(int[] nums)
    {
        const int modulo = 1_000_000_007;
        var primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

        var factorsMasksMap = new Dictionary<int, int>();

        foreach (var num in nums)
        {
            if (factorsMasksMap.ContainsKey(num))
            {
                continue;
            }

            var temp = num;
            factorsMasksMap[num] = 0;
            var primeIndex = 0;

            foreach (var prime in primes)
            {
                if (temp == 1)
                {
                    break;
                }

                if (temp % prime == 0)
                {
                    factorsMasksMap[num] |= 1 << primeIndex;
                    temp /= prime;

                    if (temp % prime == 0)
                    {
                        factorsMasksMap[num] = -1;
                        break;
                    }
                }

                primeIndex++;
            }
        }

        var dp = new DynamicProgramming<(int index, int setPrimeFactorsMask), int>((key, recursiveFunc) =>
        {
            var (index, setPrimeFactorsMask) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            for (var i = index; i < nums.Length; i++)
            {
                var num = nums[i];

                var numPrimeFactorsMask = factorsMasksMap[num];

                if (numPrimeFactorsMask == -1 || (numPrimeFactorsMask & setPrimeFactorsMask) != 0)
                {
                    continue;
                }

                return (1 + recursiveFunc((i + 1, numPrimeFactorsMask | setPrimeFactorsMask)) + recursiveFunc((i + 1, setPrimeFactorsMask))) % modulo;
            }

            return 0;
        });

        var squareFreeSubsets = dp.GetOrCalculate((0, 0));
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
