using System.Numerics;
using System.Text;

namespace LeetCode.Problems._3519_Count_Numbers_with_Non_Decreasing_Digits;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-445/problems/count-numbers-with-non-decreasing-digits/submissions/1605230195/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int CountNumbers(string l, string r, int b)
    {
        var maxDigit = (char) ('0' + (b - 1));

        var dp = new DynamicProgramming<(string maxNumBaseStr, int minDigit), ModNumber>((key, recursiveFunc) =>
        {
            var (maxNumBaseStr, minDigit) = key;

            ModNumber ans = 0;

            if (maxNumBaseStr == "")
            {
                return 1;
            }

            var firstDigit = maxNumBaseStr[0] - '0';

            for (var digit = minDigit; digit < b; digit++)
            {
                string nextMaxNumBaseStr;

                if (digit < firstDigit)
                {
                    nextMaxNumBaseStr = new string(maxDigit, maxNumBaseStr.Length - 1);
                }
                else if (digit == firstDigit)
                {
                    nextMaxNumBaseStr = maxNumBaseStr[1..];
                }
                else
                {
                    break;
                }

                ans += recursiveFunc((nextMaxNumBaseStr, digit));
            }

            return ans;
        });

        return CountAll(BigInteger.Parse(r)) - CountAll(BigInteger.Parse(l) - 1);

        ModNumber CountAll(BigInteger maxNum)
        {
            var maxNumBaseStr = ToBaseStr(maxNum);
            return dp.GetOrCalculate((maxNumBaseStr, 0));
        }

        string ToBaseStr(BigInteger num)
        {
            var sb = new StringBuilder();

            while (num > 0)
            {
                var digit = (int) (num % b);
                sb.Insert(0, digit);
                num /= b;
            }

            return sb.ToString();
        }
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
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

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
