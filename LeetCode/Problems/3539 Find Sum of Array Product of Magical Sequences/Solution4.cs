using System.Numerics;

namespace LeetCode.Problems._3539_Find_Sum_of_Array_Product_of_Magical_Sequences;

/// <summary>
/// https://leetcode.com/problems/find-sum-of-array-product-of-magical-sequences/submissions/1800946082/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MagicalSum(int m, int k, int[] nums)
    {
        var n = nums.Length;

        var factDp = new DynamicProgramming<int, ModNumber>((num, getOrCalculate) =>
        {
            if (num == 0)
            {
                return 1;
            }
            return num * getOrCalculate(num - 1);
        });

        var coefficientDp = new DynamicProgramming<(int idx, int c), ModNumber>((key, _) =>
        {
            var (idx, c) = key;
            return ModNumber.Pow(nums[idx], c) / factDp.GetOrCalculate(c);
        });

        var dp = new DynamicProgramming<(int index, int numbersUsedCount, int carry, int s), ModNumber>((key, getOrCalculate) =>
        {
            var (index, numbersUsedCount, carry, s) = key;

            if (index == n)
            {
                if (numbersUsedCount != m)
                {
                    return 0;
                }
                var extra = Popcount(carry);
                return (s + extra == k) ? 1 : 0;
            }

            ModNumber ans = 0;
            var maxC = m - numbersUsedCount;
            for (var c = 0; c <= maxC; c++)
            {
                var nsBit = (carry + c) & 1;
                var ns = s + nsBit;

                if (ns > k)
                {
                    continue;
                }

                var nCarry = (carry + c) >> 1;

                var ways = getOrCalculate((index + 1, numbersUsedCount + c, nCarry, ns));
                if (ways != 0)
                {
                    ans += ways * coefficientDp.GetOrCalculate((index, c));
                }
            }
            return ans;
        });

        var total = dp.GetOrCalculate((0, 0, 0, 0));
        total *= factDp.GetOrCalculate(m);
        return total;
    }

    private static int Popcount(int x)
    {
        var ans = 0;

        while (x != 0)
        {
            ans += x & 1;
            x /= 2;
        }
        return ans;
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

        public static ModNumber operator +(ModNumber a, ModNumber b) => new(a._value + b._value);
        public static ModNumber operator -(ModNumber a, ModNumber b) => new(a._value - b._value);
        public static ModNumber operator *(ModNumber a, ModNumber b) => new(1L * a._value * b._value);

        public static ModNumber operator /(ModNumber a, ModNumber b)
        {
            if (b == 0) throw new DivideByZeroException();
            var inverse = Pow(b, Modulo - 2);
            return a * inverse;
        }

        public static ModNumber Pow(ModNumber value, BigInteger exponent)
            => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
