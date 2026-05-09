namespace LeetCode.Problems._3629_Minimum_Jumps_to_Reach_End_via_Prime_Teleportation;

/// <summary>
/// https://leetcode.com/problems/minimum-jumps-to-reach-end-via-prime-teleportation/submissions/1997838995/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MinJumps(int[] nums)
    {
        var n = nums.Length;

        if (n == 1)
        {
            return 0;
        }

        var set = nums.ToHashSet();
        var max = nums.Max();
        var sieve = new SortedSet<int>(Enumerable.Range(2, max - 1));
        var primes = new SortedSet<int>();
        var numToPrimeFactors = new Dictionary<int, List<int>> { [1] = new() };

        while (sieve.Count > 0)
        {
            var prime = sieve.Min;
            sieve.Remove(prime);
            primes.Add(prime);
            var hasPrime = set.Contains(prime);

            for (var m = prime; m <= max; m += prime)
            {
                if (hasPrime && set.Contains(m))
                {
                    numToPrimeFactors.TryAdd(m, new List<int>());
                    numToPrimeFactors[m].Add(prime);
                }
                sieve.Remove(m);
            }
        }

        var primeToIndices = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (primes.Contains(num))
            {
                primeToIndices.TryAdd(num, new List<int>());
                primeToIndices[num].Add(i);
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

            foreach (var primeIndex in numToPrimeFactors.GetValueOrDefault(num, new List<int>()).Where(primesHandled.Add).SelectMany(prime => primeToIndices[prime]))
            {
                queue.Enqueue((primeIndex, value + 1));
            }
        }

        return dp[0];
    }
}
