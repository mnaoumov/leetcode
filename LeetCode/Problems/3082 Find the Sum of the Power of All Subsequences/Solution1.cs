using System.Numerics;

namespace LeetCode.Problems._3082_Find_the_Sum_of_the_Power_of_All_Subsequences;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-126/submissions/detail/1205422000/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SumOfPower(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int subsequenceLength, int restSum), ModNumber>((key, recursiveFunc) =>
        {
            var (index, subsequenceLength, restSum) = key;

            if (restSum == 0)
            {
                return ModNumber.Pow(2, n - subsequenceLength);
            }

            if (index == n || restSum < 0)
            {
                return 0;
            }

            return recursiveFunc((index + 1, subsequenceLength, restSum)) +
                   recursiveFunc((index + 1, subsequenceLength + 1, restSum - nums[index]));
        });

        return dp.GetOrCalculate((0, 0, k));
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

        private ModNumber(BigInteger value) => _value = value >= 0 ? Mod(value) : Mod(value) + Modulo;

        private static int Mod(BigInteger value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator ModNumber(BigInteger value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;
        public static implicit operator BigInteger(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public static ModNumber Pow(ModNumber modNumber1, ModNumber modNumber2) =>
            BigInteger.ModPow(modNumber1, modNumber2, Modulo);

        public override string ToString() => _value.ToString();
    }
}
