using System.Numerics;

namespace LeetCode.Problems._3699_Number_of_ZigZag_Arrays_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-469/problems/number-of-zigzag-arrays-i/submissions/1784822565/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int ZigZagArrays(int n, int l, int r)
    {
        var dp = new DynamicProgramming<(int itemsLeft, int previous, Direction direction), ModNumber>((key, getOrCalculate) =>
        {
            var (itemsLeft, previous, direction) = key;

            if (itemsLeft == 0)
            {
                return 1;
            }

            ModNumber ans2 = 0;

            switch (direction)
            {
                case Direction.Increasing:
                    for (var i = l; i < previous; i++)
                    {
                        ans2 += getOrCalculate((itemsLeft - 1, i, Direction.Decreasing));
                    }
                    return ans2;
                case Direction.Decreasing:
                    for (var i = previous + 1; i <= r; i++)
                    {
                        ans2 += getOrCalculate((itemsLeft - 1, i, Direction.Increasing));
                    }
                    return ans2;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        });

        ModNumber ans = 0;

        for (var i = l; i <= r; i++)
        {
            ans += dp.GetOrCalculate((n - 1, i, Direction.Increasing));
            ans += dp.GetOrCalculate((n - 1, i, Direction.Decreasing));
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

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate<ModNumber, ModNumber>(0, (current, number) => current + number);

        public static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }

    private enum Direction
    {
        Increasing,
        Decreasing
    }
}
