// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable MemberCanBePrivate.Local
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Global

namespace LeetCode.Templates;

public static class CombinatoricsTemplate
{
    // Factorials and inverse factorials up to max, mod a prime, so Choose and Permutations are O(1) each.
    public sealed class Combinatorics
    {
        public const int Modulo = 1_000_000_007;
        private readonly long[] _factorials;
        private readonly long[] _inverseFactorials;

        public Combinatorics(int max)
        {
            _factorials = new long[max + 1];
            _inverseFactorials = new long[max + 1];
            _factorials[0] = 1;

            for (var i = 1; i <= max; i++)
            {
                _factorials[i] = _factorials[i - 1] * i % Modulo;
            }

            _inverseFactorials[max] = Pow(_factorials[max], Modulo - 2);

            for (var i = max; i > 0; i--)
            {
                _inverseFactorials[i - 1] = _inverseFactorials[i] * i % Modulo;
            }
        }

        public long Factorial(int n) => _factorials[n];

        public long InverseFactorial(int n) => _inverseFactorials[n];

        /// <summary>n choose k; 0 when k &lt; 0 or k &gt; n.</summary>
        public long Choose(int n, int k) =>
            k < 0 || k > n ? 0 : _factorials[n] * _inverseFactorials[k] % Modulo * _inverseFactorials[n - k] % Modulo;

        /// <summary>Ordered selections of k from n; 0 when k &lt; 0 or k &gt; n.</summary>
        public long Permutations(int n, int k) => k < 0 || k > n ? 0 : _factorials[n] * _inverseFactorials[n - k] % Modulo;

        /// <summary>Ways to put n identical items into k boxes (stars and bars).</summary>
        public long Multichoose(int n, int k) => n == 0 && k == 0 ? 1 : Choose(n + k - 1, k - 1);

        public static long Pow(long value, long exponent)
        {
            var result = 1L;
            value %= Modulo;

            if (value < 0)
            {
                value += Modulo;
            }

            while (exponent > 0)
            {
                if ((exponent & 1) == 1)
                {
                    result = result * value % Modulo;
                }

                value = value * value % Modulo;
                exponent >>= 1;
            }

            return result;
        }

        public static long Inverse(long value) => Pow(value, Modulo - 2);
    }
}
