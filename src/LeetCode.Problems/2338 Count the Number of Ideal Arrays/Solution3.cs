using System.Numerics;

namespace LeetCode.Problems._2338_Count_the_Number_of_Ideal_Arrays;

/// <summary>
/// https://leetcode.com/problems/count-the-number-of-ideal-arrays/submissions/1614130814/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int IdealArrays(int n, int maxValue)
    {
        var factorials = new ModNumber[n + (int) Math.Log2(maxValue)];
        factorials[0] = 1;

        for (var i = 1; i < factorials.Length; i++)
        {
            factorials[i] = factorials[i - 1] * i;
        }

        var primes = new List<int>();

        for (var m = 2; m <= maxValue; m++)
        {
            var isPrime = primes.TakeWhile(p => p * p <= m).All(p => m % p != 0);

            if (isPrime)
            {
                primes.Add(m);
            }
        }

        ModNumber ans = 1;

        for (var last = 2; last <= maxValue; last++)
        {
            var temp = last;
            ModNumber count = 1;

            foreach (var prime in primes)
            {
                var power = 0;
                while (temp % prime == 0)
                {
                    power++;
                    temp /= prime;
                }

                if (power > 0)
                {
                    count *= Choose(power + n - 1, power);
                }

                if (temp == 1)
                {
                    break;
                }
            }

            ans += count;
        }

        return ans;

        ModNumber Choose(int m, int k) => Factorial(m) / Factorial(k) / Factorial(m - k);
        ModNumber Factorial(int m) => factorials[m];
    }

    private class ModNumber
    {
        private const int Modulo = 1_000_000_007;
        private readonly int _value;

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber operator /(ModNumber modNumber1, ModNumber modNumber2)
        {
            if (modNumber2 == 0)
            {
                throw new DivideByZeroException();
            }

            var inverse = Pow(modNumber2, Modulo - 2);
            return modNumber1 * inverse;
        }

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);
        public override string ToString() => _value.ToString();
    }
}
