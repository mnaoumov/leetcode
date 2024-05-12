using JetBrains.Annotations;

namespace LeetCode.Problems._2147_Number_of_Ways_to_Divide_a_Long_Corridor;

/// <summary>
/// https://leetcode.com/submissions/detail/1107791411/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int NumberOfWays(string corridor)
    {
        var n = corridor.Length;
        const char seat = 'S';

        var seatIndices = Enumerable.Range(0, n).Where(i => corridor[i] == seat).ToArray();
        const int noSeatIndex = int.MaxValue;

        var dp = new DynamicProgramming<int, ModNumber>((corridorIndex, recursiveFunc) =>
        {
            var seatIndex1 = NextSeatIndex(corridorIndex);
            var seatIndex2 = NextSeatIndex(seatIndex1 + 1);

            if (seatIndex2 == noSeatIndex)
            {
                return 0;
            }

            var seatIndex3 = NextSeatIndex(seatIndex2 + 1);

            if (seatIndex3 == noSeatIndex)
            {
                return 1;
            }

            return (seatIndex3 - seatIndex2) * recursiveFunc(seatIndex3);
        });

        return dp.GetOrCalculate(0);

        int NextSeatIndex(int seatIndex)
        {
            var indexOfIndex = Array.BinarySearch(seatIndices, seatIndex);

            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            return indexOfIndex == seatIndices.Length ? noSeatIndex : seatIndices[indexOfIndex];
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

        private ModNumber(long value) => _value = value >= 0 ? Mod(value) : Mod(Mod(value) + Modulo);

        private static int Mod(long value) => (int) (value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();
    }
}
