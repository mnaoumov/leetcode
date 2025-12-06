using System.Numerics;

namespace LeetCode.Problems._3578_Count_Partitions_With_Max_Min_Difference_at_Most_K;

/// <summary>
/// https://leetcode.com/problems/count-partitions-with-max-min-difference-at-most-k/submissions/1847990584/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountPartitions(int[] nums, int k)
    {
        var n = nums.Length;
        var dp = new DynamicProgramming<(int index, int min, int max), ModNumber>((key, getOrCalculate) =>
        {
            var (index, min, max) = key;

            if (index == n)
            {
                return 1;
            }

            var num = nums[index];
            var ans = getOrCalculate((index + 1, num, num));

            var nextMin = Math.Min(min, num);
            var nextMax = Math.Max(max, num);

            if (nextMax - nextMin <= k)
            {
                ans += getOrCalculate((index + 1, nextMin, nextMax));
            }

            return ans;
        });

        return dp.GetOrCalculate((1, nums[0], nums[0]));
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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
