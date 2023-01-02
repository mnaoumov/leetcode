using JetBrains.Annotations;

namespace LeetCode._2521_Distinct_Prime_Factors_of_Product_of_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/869881372/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DistinctPrimeFactors(int[] nums)
    {
        var primes = new List<int>();
        var primesBoundChecked = 1;

        var primesInProduct = new HashSet<int>();

        foreach (var num in nums)
        {
            var num2 = num;

            foreach (var prime in GetPrimes().TakeWhile(prime => prime <= Math.Sqrt(num2)))
            {
                while (num2 % prime == 0)
                {
                    primesInProduct.Add(prime);
                    num2 /= prime;
                }
            }

            if (num2 > 1)
            {
                primesInProduct.Add(num2);
            }

            num2 = 1;
        }

        return primesInProduct.Count;

        IEnumerable<int> GetPrimes()
        {
            foreach (var prime in primes)
            {
                yield return prime;
            }

            while (true)
            {
                var candidate = primesBoundChecked + 1;

                if (primes.TakeWhile(prime => prime <= Math.Sqrt(candidate))
                    .All(prime => candidate % prime != 0))
                {
                    primes.Add(candidate);
                    yield return candidate;
                }

                primesBoundChecked = candidate;
            }

            // ReSharper disable once IteratorNeverReturns
        }
    }
}
