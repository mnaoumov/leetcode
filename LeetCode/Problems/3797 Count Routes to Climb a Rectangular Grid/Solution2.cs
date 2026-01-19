using System.Numerics;

namespace LeetCode.Problems._3797_Count_Routes_to_Climb_a_Rectangular_Grid;

/// <summary>
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.NotImplemented)]
public class Solution2 : ISolution
{
    public int NumberOfRoutes(string[] grid, int d)
    {
        const char block = '#';
        var n = grid.Length;
        var m = grid[0].Length;

        var availableCells = Enumerable.Range(0, n).Select(_ => new SortedSet<int>()).ToArray();

        for (var row = 0; row < n; row++)
        {
            for (var column = 0; column < m; column++)
            {
                if (grid[row][column] != block)
                {
                    availableCells[row].Add(column);
                }
            }
        }

        var dp = new DynamicProgramming<(int row, int column, bool canStayInRow), ModNumber>((key, getOrCalculate) =>
        {
            var (row, column, canStayInRow) = key;

            ModNumber ans = row == 0 ? 1 : 0;

            if (canStayInRow)
            {
                foreach (var nextColumn in availableCells[row].GetViewBetween(column - d, column + d))
                {
                    if (nextColumn == column)
                    {
                        continue;
                    }

                    ans += getOrCalculate((row, nextColumn, false));
                }
            }

            if (row == 0)
            {
                return ans;
            }

            foreach (var nextColumn in availableCells[row - 1].GetViewBetween(column - d + 1, column + d - 1))
            {
                ans += getOrCalculate((row - 1, nextColumn, true));
            }

            return ans;
        });

        return ModNumber.Sum(availableCells[n - 1].Select(column => dp.GetOrCalculate((n - 1, column, true))));
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

        private static ModNumber Pow(ModNumber value, BigInteger exponent) => (int) BigInteger.ModPow((int) value, exponent, Modulo);

        public override string ToString() => _value.ToString();
    }
}
