using System.Numerics;

namespace LeetCode.Problems._3811_Number_of_Alternating_XOR_Partitions;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-174/problems/number-of-alternating-xor-partitions/submissions/1887934555/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int AlternatingXOR(int[] nums, int target1, int target2)
    {
        var n = nums.Length;
        var prefixXor = 0;

        var indexGroups = Enumerable.Range(0, 4).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            prefixXor ^= nums[i];

            if (prefixXor == target1)
            {
                indexGroups[0].Add(i);
            }
            if (prefixXor == (target1 ^ target2))
            {
                indexGroups[1].Add(i);
            }
            if (prefixXor == target2)
            {
                indexGroups[2].Add(i);
            }
            if (prefixXor == 0)
            {
                indexGroups[3].Add(i);
            }
        }

        var dp = new DynamicProgramming<(int index, int indexGroupIndex), ModNumber>((key, getOrCalculate) =>
        {
            var (index, indexGroupIndex) = key;

            if (index == n)
            {
                return 1;
            }

            var indexGroup = indexGroups[indexGroupIndex];

            var indexOfIndex = indexGroup.BinarySearch(index);
            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            if (indexOfIndex >= indexGroup.Count)
            {
                return 0;
            }

            var nextIndex = indexGroup[indexOfIndex];

            var nextPartitionResult = getOrCalculate((nextIndex + 1, (indexGroupIndex + 1) % 4));
            var gotoNextGroupResult = nextIndex + 1 < n ? getOrCalculate((nextIndex + 1, indexGroupIndex)) : (ModNumber) 0;
            return nextPartitionResult + gotoNextGroupResult;
        });

        return dp.GetOrCalculate((0, 0));
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
}
