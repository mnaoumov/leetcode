namespace LeetCode.Problems._3629_Minimum_Jumps_to_Reach_End_via_Prime_Teleportation;

/// <summary>
/// https://leetcode.com/problems/minimum-jumps-to-reach-end-via-prime-teleportation/submissions/1997795819/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinJumps(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return 0;
        }

        var max = nums.Max();
        var maxSqrt = (int) Math.Sqrt(max);

        var primes = new SortedSet<int>();

        for (var i = 2; i <= maxSqrt; i++)
        {
            var maxP = (int) Math.Sqrt(i);
            var isPrime = primes.TakeWhile(p => p <= maxP).All(p => i % p != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        var nonPrimes = new HashSet<int>();
        var numToPrimeFactors = new Dictionary<int, List<int>>();
        var primeToIndices = new Dictionary<int, List<int>>();
        var primeToDividendIndices = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (primes.Contains(num))
            {
                primeToIndices.TryAdd(num, new List<int>());
                primeToIndices[num].Add(i);
                primeToDividendIndices.TryAdd(num, new List<int>());
                continue;
            }

            if (num <= maxSqrt || nonPrimes.Contains(num))
            {
                continue;
            }

            var isPrime = primes.All(p => num % p != 0);

            if (isPrime)
            {
                primes.Add(num);
                primeToIndices.TryAdd(num, new List<int>());
                primeToIndices[num].Add(i);
                primeToDividendIndices.TryAdd(num, new List<int>());
            }
            else
            {
                nonPrimes.Add(num);
            }
        }

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (numToPrimeFactors.TryAdd(num, new List<int>()))
            {
                foreach (var prime in primeToDividendIndices.Keys.Where(prime => num % prime == 0))
                {
                    numToPrimeFactors[num].Add(prime);
                }
            }

            foreach (var prime in numToPrimeFactors[num])
            {
                primeToDividendIndices[prime].Add(i);
            }
        }

        var dp = new int[n];
        Array.Fill(dp, int.MaxValue);

        var queue = new Queue<(int index, int value)>();
        queue.Enqueue((n - 1, 0));

        var primesHandled = new HashSet<int>();

        while (queue.Count > 0)
        {
            var (index, value) = queue.Dequeue();

            if (dp[index] <= value)
            {
                continue;
            }

            dp[index] = value;

            if (index > 0)
            {
                queue.Enqueue((index - 1, value + 1));
            }

            if (index + 1 < n)
            {
                queue.Enqueue((index + 1, value + 1));
            }

            var num = nums[index];

            foreach (var primeIndex in numToPrimeFactors[num].Where(primesHandled.Add).SelectMany(prime => primeToIndices[prime]))
            {
                queue.Enqueue((primeIndex, value + 1));
            }
        }

        return dp[0];
    }
}
