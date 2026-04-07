using System.Globalization;

namespace LeetCode.Problems._0631_Design_Excel_Sum_Formula;

/// <summary>
/// https://leetcode.com/problems/design-excel-sum-formula/submissions/1934178840/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public IExcel Create(int height, char width) => new Excel(height, width);

    private sealed class Excel : IExcel
    {
        private readonly Cell[][] _table;

        public Excel(int height, char width)
        {
            var widthNum = width - 'A' + 1;

            _table = Enumerable.Range(0, height)
                .Select(_ => Enumerable.Range(0, widthNum).Select(_ => new Cell()).ToArray()).ToArray();
        }

        public void Set(int row, char column, int val)
        {
            var cellRef = new CellRef(row, column);
            GetCell(cellRef).Value = new SimpleCellValue(val);
            RaiseCellChanged(cellRef);
        }

        private Cell GetCell(CellRef cellRef) => _table[cellRef.Row - 1][cellRef.Column - 'A'];

        public int Get(int row, char column)
        {
            return _table[row - 1][column - 'A'].Value.GetValue();
        }

        public int Sum(int row, char column, string[] numbers)
        {
            var cellRef = new CellRef(row, column);
            GetCell(cellRef).Value = new SumCellValue(this, cellRef, numbers.SelectMany(CellRef.Parse).ToArray());
            RaiseCellChanged(cellRef);
            return Get(row, column);
        }

        public event EventHandler<CellChangedEventArgs>? CellChanged;

        public void RaiseCellChanged(CellRef cellRef)
        {
            CellChanged?.Invoke(this, new CellChangedEventArgs(cellRef));
        }
    }

    private sealed class Cell : IDisposable
    {
        private CellValue _value = new SimpleCellValue(0);

        public CellValue Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value.Dispose();
                _value = value;
            }
        }

        public void Dispose()
        {
            _value.Dispose();
        }
    }

    private abstract class CellValue : IDisposable
    {
        public abstract int GetValue();
        public abstract void Dispose();
    }

    private sealed class SimpleCellValue : CellValue
    {
        private readonly int _value;
        public SimpleCellValue(int value) => _value = value;
        public override int GetValue() => _value;

        public override void Dispose()
        {
        }
    }

    private sealed class SumCellValue : CellValue
    {
        private readonly Excel _excel;
        private readonly CellRef[] _cellRefs;
        private readonly HashSet<CellRef> _cellRefsSet;
        private int? _cachedValue;
        private readonly CellRef _cellRef;

        public SumCellValue(Excel excel, CellRef cellRef, CellRef[] cellRefs)
        {
            _excel = excel;
            _cellRef = cellRef;
            _cellRefs = cellRefs;
            _cellRefsSet = cellRefs.ToHashSet();
            _excel.CellChanged += HandleCellChanged;
        }

        private void HandleCellChanged(object? sender, CellChangedEventArgs e)
        {
            if (!_cellRefsSet.Contains(e.CellRef))
            {
                return;
            }

            _cachedValue = null;
            _excel.RaiseCellChanged(_cellRef);
        }

        public override int GetValue()
        {
            _cachedValue ??= _cellRefs.Select(c => _excel.Get(c.Row, c.Column)).Sum();
            return _cachedValue.Value;
        }

        public override void Dispose()
        {
            _excel.CellChanged -= HandleCellChanged;
        }
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

    private sealed class CellChangedEventArgs : EventArgs
    {
        public CellChangedEventArgs(CellRef cellRef)
        {
            CellRef = cellRef;
        }

        public CellRef CellRef { get; init; }
    }
}
