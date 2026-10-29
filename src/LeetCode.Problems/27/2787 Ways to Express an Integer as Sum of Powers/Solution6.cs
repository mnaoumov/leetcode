using System.Numerics;

namespace LeetCode.Problems._2787_Ways_to_Express_an_Integer_as_Sum_of_Powers;

/// <summary>
/// https://leetcode.com/problems/ways-to-express-an-integer-as-sum-of-powers/submissions/1731976582/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int NumberOfWays(int n, int x)
    {
        var dp = new ModNumber[n + 1];
        Array.Fill<ModNumber>(dp, 0);
        dp[0] = 1;

        for (var i = 1; i <= n; i++)
        {
            var power = (int) Math.Pow(i, x);

            if (power > n)
            {
                break;
            }

            for (var j = n; j >= power; j--)
            {
                dp[j] += dp[j - power];
            }
        }

        return dp[n];
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

