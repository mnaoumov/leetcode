using System.Globalization;

namespace LeetCode.Problems._0631_Design_Excel_Sum_Formula;

/// <summary>
/// https://leetcode.com/problems/design-excel-sum-formula/submissions/1934168577/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public IExcel Create(int height, char width) => new Excel(height, width);

    private sealed class Excel : IExcel
    {
        private readonly Cell[][] _table;

        public Excel(int height, char width)
        {
            var widthNum = width - 'A' + 1;

            _table = Enumerable.Range(0, height)
                .Select(_ => Enumerable.Range(0, widthNum).Select(Cell (_) => new ValueCell(0)).ToArray()).ToArray();
        }

        public void Set(int row, char column, int val)
        {
            _table[row - 1][column - 'A'] = new ValueCell(val);
        }

        public int Get(int row, char column)
        {
            return _table[row - 1][column - 'A'].GetValue();
        }

        public int Sum(int row, char column, string[] numbers)
        {
            _table[row - 1][column - 'A'] = new SumCell(this, numbers.SelectMany(CellRef.Parse).ToArray());
            return Get(row, column);
        }
    }

    private abstract class Cell
    {
        public abstract int GetValue();
    }

    private sealed class ValueCell : Cell
    {
        private readonly int _value;
        public ValueCell(int value) => _value = value;
        public override int GetValue() => _value;
    }

    private sealed class SumCell : Cell
    {
        private readonly Excel _excel;
        private readonly CellRef[] _cellRefs;

        public SumCell(Excel excel, CellRef[] cellRefs)
        {
            _excel = excel;
            _cellRefs = cellRefs;
        }

        public override int GetValue() => _cellRefs.Select(c => _excel.Get(c.Row, c.Column)).Sum();
    }

    private sealed record CellRef(int Row, char Column)
    {
        public static CellRef[] Parse(string str)
        {
            var parts = str.Split(':');

            if (parts.Length == 1)
            {
                return new[] { ParseSingle(str) };
            }

            var leftTop = ParseSingle(parts[0]);
            var rightBottom = ParseSingle(parts[1]);
            var list = new List<CellRef>();

            for (var row = leftTop.Row; row <= rightBottom.Row; row++)
            {
                for (var column = leftTop.Column; column <= rightBottom.Column; column++)
                {
                    list.Add(new CellRef(row, column));
                }
            }

            return list.ToArray();
        }

        private static CellRef ParseSingle(string str)
        {
            var row = int.Parse(str[1..], CultureInfo.InvariantCulture);
            var column = str[0];
            return new CellRef(row, column);
        }
    }
}
