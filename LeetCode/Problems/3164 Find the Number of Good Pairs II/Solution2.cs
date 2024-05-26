using JetBrains.Annotations;

namespace LeetCode.Problems._3164_Find_the_Number_of_Good_Pairs_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1268100002/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public long NumberOfPairs(int[] nums1, int[] nums2, int k)
    {
        var num1DividedByKCounts = new Dictionary<int, int>();

        foreach (var num1 in nums1)
        {
            if (num1 % k != 0)
            {
                continue;
            }

            var num1DividedByK = num1 / k;

            num1DividedByKCounts.TryAdd(num1DividedByK, 0);
            num1DividedByKCounts[num1DividedByK]++;
        }

        var max = num1DividedByKCounts.Keys.Max();

        var primes = new List<int>();

        for (var i = 2; i <= max; i++)
        {
            var isPrime = primes.TakeWhile(prime => prime * prime <= i).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        var num2Counts = nums2.GroupBy(num2 => num2).ToDictionary(g => g.Key, g => g.Count());

        var ans = 0L;

        foreach (var (num1DividedByK, count1) in num1DividedByKCounts)
        {
            var temp = num1DividedByK;
            var primeDivisors = new Dictionary<int, int>();

            if (temp > 1)
            {
                foreach (var prime in primes)
                {
                    while (temp % prime == 0)
                    {
                        temp /= prime;
                        primeDivisors.TryAdd(prime, 0);
                        primeDivisors[prime]++;

                        if (temp == 1)
                        {
                            break;
                        }
                    }
                }
            }

            foreach (var divisor in GetAllDivisors(primeDivisors))
            {
                if (num2Counts.TryGetValue(divisor, out var count2))
                {
                    ans += 1L * count1 * count2;
                }
            }
        }

        return ans;
    }

    private static IEnumerable<int> GetAllDivisors(IDictionary<int, int> primeDivisors)
    {
        var pairs = primeDivisors.Select(kvp => (prime: kvp.Key, power: kvp.Value)).ToArray();

        return ListDivisors(0);

        IEnumerable<int> ListDivisors(int index)
        {
            if (index == pairs.Length)
            {
                yield return 1;
                yield break;
            }

            var (prime, power) = pairs[index];

            var poweredPrime = 1;

            for (var j = 0; j <= power ; j++)
            {
                foreach (var nextDivisor in ListDivisors(index+1))
                {
                    yield return poweredPrime * nextDivisor;
                }

                poweredPrime *= prime;
            }

        }
    }
}
