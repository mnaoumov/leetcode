namespace LeetCode.Problems._0935_Knight_Dialer;

/// <summary>
/// https://leetcode.com/submissions/detail/1107087888/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int KnightDialer(int n)
    {
        var moves = new Dictionary<int, int[]>
        {
            [0] = new[] { 4, 6 },
            [1] = new[] { 6, 8 },
            [2] = new[] { 7, 9 },
            [3] = new[] { 4, 8 },
            [4] = new[] { 0, 3, 9 },
            [5] = Array.Empty<int>(),
            [6] = new[] { 0, 1, 7 },
            [7] = new[] { 2, 6 },
            [8] = new[] { 1, 3 },
            [9] = new[] { 2, 4 }
        };

        var dp = new DynamicProgramming<(int previousCell, int movesCount), ModNumber>((key, recursiveFunc) =>
        {
            var (previousCell, movesCount) = key;

            if (movesCount == 0)
            {
                return 1;
            }

            return ModNumber.Sum(moves[previousCell].Select(cell => recursiveFunc((cell, movesCount - 1))));
        });

        return ModNumber.Sum(Enumerable.Range(0, 10).Select(i => dp.GetOrCalculate((i, n - 1))));
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

        private static int Mod(long value) => (int)(value % Modulo);

        public static implicit operator ModNumber(int value) => new(value);
        public static implicit operator int(ModNumber modNumber) => modNumber._value;

        public static ModNumber operator +(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value + modNumber2._value);

        public static ModNumber operator -(ModNumber modNumber1, ModNumber modNumber2) =>
            new(modNumber1._value - modNumber2._value);

        public static ModNumber operator *(ModNumber modNumber1, ModNumber modNumber2) =>
            new(1L * modNumber1._value * modNumber2._value);

        public override string ToString() => _value.ToString();

        public static ModNumber Sum(IEnumerable<ModNumber> numbers) =>
            numbers.Aggregate((ModNumber) 0, (a, b) => a + b);
    }
}
