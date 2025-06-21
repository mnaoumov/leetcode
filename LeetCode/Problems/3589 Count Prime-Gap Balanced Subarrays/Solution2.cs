namespace LeetCode.Problems._3589_Count_Prime_Gap_Balanced_Subarrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-159/problems/count-prime-gap-balanced-subarrays/submissions/1671747250/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int PrimeSubarray(int[] nums, int k)
    {
        var maxNum = nums.Max();
        var primeBound = (int) Math.Sqrt(maxNum) + 1;
        var primes = new List<int>();

        for (var i = 2; i <= primeBound; i++)
        {
            var isPrime = primes.TakeWhile(prime => prime * prime <= i).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        var primeSet = primes.ToHashSet();

        var primesInNums = nums.Distinct().Where(IsPrime).ToHashSet();

        var dp = new DynamicProgramming<(int index, int min, int max, int primesCount), int>((key, recursiveFunc) =>
        {
            var (index, min, max, primesCount) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            if (min == 0)
            {
                return recursiveFunc((index + 1, 0, max, primesCount)) + recursiveFunc((index, 1, max, primesCount));
            }

            var num = nums[index];

            if (!primesInNums.Contains(num))
            {
                return (primesCount >= 2 ? 1 : 0) + recursiveFunc((index + 1, min, max, primesCount));
            }

            if (num < min || num > max)
            {
                return 0;
            }

            return (primesCount >= 1 ? 1 : 0)
                   + recursiveFunc((index + 1, Math.Max(min, num - k),
                       Math.Min(max, num + k),
                       Math.Min(primesCount + 1, 2)));
        });

        return dp.GetOrCalculate((0, 0, maxNum, 0));


        bool IsPrime(int num) => primeSet.Contains(num) || num > primeBound && primes.All(prime => num % prime != 0);
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
