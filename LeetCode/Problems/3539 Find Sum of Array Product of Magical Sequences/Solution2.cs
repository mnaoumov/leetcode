using System.Numerics;

namespace LeetCode.Problems._3539_Find_Sum_of_Array_Product_of_Magical_Sequences;

/// <summary>
/// https://leetcode.com/problems/find-sum-of-array-product-of-magical-sequences/submissions/1798835008/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
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


        var dp = new DynamicProgramming<(int index, int numbersTaken, long mask), ModNumber>((key, getOrCalculate) =>
        {
            var (index, numbersTaken, mask) = key;

            if (index == n)
            {
                return numbersTaken == m && BitCount(mask) == k ? factDp.GetOrCalculate(m) : 0;
            }

            ModNumber ans = 0;

            for (var count = 0; count <= m - numbersTaken; count++)
            {
                ans += getOrCalculate((index + 1, numbersTaken + count, mask + (1 << index) * count)) *
                    ModNumber.Pow(nums[index], count) / factDp.GetOrCalculate(count);
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0, 0));
    }

    private static int BitCount(long mask)
    {
        var ans = 0;
        while (mask > 0)
        {
            ans += (int) (mask & 1);
            mask >>= 1;
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
