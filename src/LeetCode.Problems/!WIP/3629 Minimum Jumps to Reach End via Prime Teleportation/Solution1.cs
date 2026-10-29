namespace LeetCode.Problems._3629_Minimum_Jumps_to_Reach_End_via_Prime_Teleportation;

/// <summary>
/// https://leetcode.com/problems/minimum-jumps-to-reach-end-via-prime-teleportation/submissions/1997771340/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinJumps(int[] nums)
    {
        var n = nums.Length;
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

        var primeToIndices = new Dictionary<int, List<int>>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];
            if (num <= maxSqrt)
            {
                if (!primes.Contains(num))
                {
                    continue;
                }
            }
            else
            {
                var isPrime = primes.All(p => num % p != 0);

                if (!isPrime)
                {
                    continue;
                }
            }

            primeToIndices.TryAdd(num, new List<int>());
            primeToIndices[num].Add(i);
        }

        var primeJumpPairs = new List<(int from, int to)>();

        foreach (var primeIndices in primeToIndices.Values)
        {
            for (var i = 0; i < primeIndices.Count; i++)
            {
                for (var j = i + 1; j < primeIndices.Count; j++)
                {
                    primeJumpPairs.Add((primeIndices[i], primeIndices[j]));
                    primeJumpPairs.Add((primeIndices[j], primeIndices[i]));
                }
            }
        }

        for (var index = 0; index < n; index++)
        {
            var num = nums[index];

            if (primeToIndices.ContainsKey(num))
            {
                continue;
            }

            foreach (var (prime, primeIndices) in primeToIndices)
            {
                if (num % prime != 0)
                {
                    continue;
                }

                primeJumpPairs.AddRange(primeIndices.Select(primeIndex => (primeIndex, index)));
            }
        }

        var dp = new int[n];
        Array.Fill(dp, int.MaxValue);
        dp[^1] = 0;

        var hasChanges = true;

        while (hasChanges)
        {
            hasChanges = false;
            for (var i = n - 2; i >= 0; i--)
            {
                var candidate = dp[i + 1] + 1;

                if (candidate >= dp[i])
                {
                    continue;
                }

                hasChanges = true;
                dp[i] = candidate;
            }

            for (var i = 1; i < n; i++)
            {
                var candidate = dp[i - 1] + 1;

                if (candidate >= dp[i])
                {
                    continue;
                }

                hasChanges = true;
                dp[i] = candidate;
            }

            foreach (var (from, to) in primeJumpPairs)
            {
                var candidate = dp[to] + 1;
                if (candidate >= dp[from])
                {
                    continue;
                }

                hasChanges = true;
                dp[from] = candidate;
            }
        }

        return dp[0];
    }
}
