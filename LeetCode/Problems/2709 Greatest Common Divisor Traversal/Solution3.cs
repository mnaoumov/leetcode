using JetBrains.Annotations;

namespace LeetCode.Problems._2709_Greatest_Common_Divisor_Traversal;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-105/submissions/detail/958419588/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public bool CanTraverseAllPairs(int[] nums)
    {
        if (nums.Length == 1)
        {
            return true;
        }

        const int maxNum = 100_000;

        var primes = new List<int>();

        for (var i = 2; i <= maxNum; i++)
        {
            var isPrime = primes.TakeWhile(prime => prime * prime <= i).All(prime => i % prime != 0);

            if (isPrime)
            {
                primes.Add(i);
            }
        }

        var primesSet = primes.ToHashSet();

        var uf = new UnionFind<int>();

        var allPrimeFactors = new HashSet<int>();

        foreach (var num in nums)
        {
            if (num == 1)
            {
                return false;
            }

            var primeFactors = PrimeFactors(num);
            allPrimeFactors.UnionWith(primeFactors);

            var factor1 = primeFactors.First();

            foreach (var factor2 in primeFactors)
            {
                uf.Union(factor1, factor2);
            }
        }

        var factor3 = allPrimeFactors.Min();

        return allPrimeFactors.All(factor2 => uf.Connected(factor2, factor3));

        HashSet<int> PrimeFactors(int num)
        {
            var ans = new HashSet<int>();

            var primeIndex = 0;

            while (num > 1)
            {
                if (primesSet.Contains(num))
                {
                    ans.Add(num);
                    break;
                }

                var prime = primes[primeIndex];

                if (num % prime == 0)
                {
                    while (num % prime == 0)
                    {
                        num /= prime;
                    }

                    ans.Add(prime);
                }

                primeIndex++;
            }

            return ans;
        }
    }

    private class UnionFind<T> where T : IEquatable<T>
    {
        private readonly Dictionary<T, T> _roots = new();
        private readonly Dictionary<T, int> _ranks = new();

        private T Find(T x) => _roots.GetValueOrDefault(x, x).Equals(x) ? x : _roots[x] = Find(_roots[x]);

        public void Union(T x, T y)
        {
            var rootX = Find(x);
            var rootY = Find(y);

            if (rootX.Equals(rootY))
            {
                return;
            }

            var rankX = GetRank(rootX);
            var rankY = GetRank(rootY);

            if (rankX < rankY)
            {
                _roots[rootX] = rootY;
            }
            else if (rankX > rankY)
            {
                _roots[rootY] = rootX;
            }
            else
            {
                _roots[rootX] = rootY;
                _ranks[rootY] = rankY + 1;
            }
        }

        private int GetRank(T x) => _ranks.GetValueOrDefault(x, 1);

        public bool Connected(T x, T y) => Find(x).Equals(Find(y));
    }
}
