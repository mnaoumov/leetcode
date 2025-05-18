using System.Numerics;
using System.Text;

namespace LeetCode.Problems._1931_Painting_a_Grid_With_Three_Different_Colors;

/// <summary>
/// https://leetcode.com/problems/painting-a-grid-with-three-different-colors/submissions/1636839028/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int ColorTheGrid(int m, int n)
    {
        const char red = 'R';
        const char green = 'G';
        const char blue = 'B';
        var colors = new[] { red, green, blue };


        var possibleColumns = new List<string>();
        GeneratePossibleColumns(new StringBuilder());

        var columnNeighbors = new Dictionary<string, List<string>>
        {
            [""] = possibleColumns
        };

        foreach (var column in possibleColumns)
        {
            columnNeighbors[column] = new List<string>();

            foreach (var column2 in possibleColumns.Where(column2 => IsValidNeighbor(column, column2)))
            {
                columnNeighbors[column].Add(column2);
            }
        }

        var dp = new DynamicProgramming<(string previousColumn, int columnIndex), ModNumber>((key, recursiveFunc) =>
        {
            var (previousColumn, columnIndex) = key;

            if (columnIndex == n)
            {
                return 1;
            }

            return ModNumber.Sum(
                columnNeighbors[previousColumn]
                    .Select(column => recursiveFunc((column, columnIndex + 1)))
            );
        });

        return dp.GetOrCalculate(("", 0));

        bool IsValidNeighbor(string column1, string column2)
        {
            for (var i = 0; i < m; i++)
            {
                if (column1[i] == column2[i])
                {
                    return false;
                }
            }

            return true;
        }


        void GeneratePossibleColumns(StringBuilder sb)
        {
            if (sb.Length == m)
            {
                possibleColumns.Add(sb.ToString());
                return;
            }

            foreach (var color in colors)
            {
                if (sb.Length > 0 && sb[^1] == color)
                {
                    continue;
                }

                sb.Append(color);
                GeneratePossibleColumns(sb);
                sb.Remove(sb.Length - 1, 1);
            }
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
