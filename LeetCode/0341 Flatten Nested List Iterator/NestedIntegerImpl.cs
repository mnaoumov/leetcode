namespace LeetCode._0341_Flatten_Nested_List_Iterator;

public class NestedIntegerImpl : NestedInteger
{
    private readonly NestedInteger[]? _values;
    private readonly int _value;

    public NestedIntegerImpl(int value)
    {
        _value = value;
    }

    public NestedIntegerImpl(NestedInteger[] values)
    {
        _values = values;
    }

    public bool IsInteger() => _values == null;

    public int GetInteger() => IsInteger() ? _value : default;

    public IList<NestedInteger>? GetList() => !IsInteger() ? _values : null;
}