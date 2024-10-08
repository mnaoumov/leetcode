namespace LeetCode.Problems._2750_Ways_to_Split_Array_Into_Good_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/979007264/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int NumberOfGoodSubarraySplits(int[] nums)
    {
        var n = nums.Length;
        var oneIndices = Enumerable.Range(0, n).Where(i => nums[i] == 1).ToArray();

        var dp = new DynamicProgramming<int, ModNumber>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return 0;
            }

            var indexOfIndex = Array.BinarySearch(oneIndices, index);

            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            if (indexOfIndex == oneIndices.Length)
            {
                return 0;
            }

            var firstIndex = oneIndices[indexOfIndex];

            indexOfIndex = Array.BinarySearch(oneIndices, firstIndex + 1);

            if (indexOfIndex < 0)
            {
                indexOfIndex = ~indexOfIndex;
            }

            var secondIndex = indexOfIndex < oneIndices.Length ? oneIndices[indexOfIndex] : n;

            return secondIndex == n ? 1 : (secondIndex - firstIndex) * recursiveFunc(secondIndex);
        });

        return dp.GetOrCalculate(0);
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
