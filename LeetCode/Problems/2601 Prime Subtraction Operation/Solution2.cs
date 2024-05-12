using JetBrains.Annotations;

namespace LeetCode.Problems._2601_Prime_Subtraction_Operation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-338/submissions/detail/922162310/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public bool PrimeSubOperation(int[] nums)
    {
        var primes = new List<int>();

        for (var i = 2; i <= 1000; i++)
        {
            var bound = (int) Math.Sqrt(i);
            var isPrime = primes.Where(p => p <= bound).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        for (var i = nums.Length - 2; i >= 0; i--)
        {
            var num = nums[i];
            var nextNum = nums[i + 1];
            var diff = num - nextNum;

            if (diff < 0)
            {
                continue;
            }

            var primeIndex = primes.BinarySearch(diff + 1);

            if (primeIndex < 0)
            {
                primeIndex = ~primeIndex;
            }

            if (primeIndex >= primes.Count)
            {
                return false;
            }

            var minPrime = primes[primeIndex];

            if (minPrime >= num)
            {
                return false;
            }

            nums[i] -= minPrime;
        }

        return true;
    }
}
