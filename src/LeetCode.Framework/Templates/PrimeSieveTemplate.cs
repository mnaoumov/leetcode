// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class PrimeSieveTemplate
{
    // Linear sieve: every number in [0, max] gets its smallest prime factor in O(max).
    public sealed class PrimeSieve
    {
        private readonly int[] _smallestPrimeFactors;
        private readonly List<int> _primes = [];

        public PrimeSieve(int max)
        {
            _smallestPrimeFactors = new int[max + 1];

            for (var i = 2; i <= max; i++)
            {
                if (_smallestPrimeFactors[i] == 0)
                {
                    _smallestPrimeFactors[i] = i;
                    _primes.Add(i);
                }

                foreach (var prime in _primes)
                {
                    if (prime > _smallestPrimeFactors[i] || (long) prime * i > max)
                    {
                        break;
                    }

                    _smallestPrimeFactors[prime * i] = prime;
                }
            }
        }

        /// <summary>The primes up to max, ascending.</summary>
        public IReadOnlyList<int> Primes => _primes;

        public bool IsPrime(int n) => n >= 2 && _smallestPrimeFactors[n] == n;

        /// <summary>0 for n &lt; 2.</summary>
        public int SmallestPrimeFactor(int n) => _smallestPrimeFactors[n];

        /// <summary>The (prime, exponent) pairs of n &gt;= 1, primes ascending; empty for 1.</summary>
        public IEnumerable<(int Prime, int Exponent)> Factorise(int n)
        {
            while (n > 1)
            {
                var prime = _smallestPrimeFactors[n];
                var exponent = 0;

                while (n % prime == 0)
                {
                    n /= prime;
                    exponent++;
                }

                yield return (prime, exponent);
            }
        }
    }

    // Trial division, for a single n too large to sieve (up to long.MaxValue).
    public static bool IsPrime(long n)
    {
        if (n < 2)
        {
            return false;
        }

        if (n % 2 == 0)
        {
            return n == 2;
        }

        for (long divisor = 3; divisor <= n / divisor; divisor += 2)
        {
            if (n % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }
}
