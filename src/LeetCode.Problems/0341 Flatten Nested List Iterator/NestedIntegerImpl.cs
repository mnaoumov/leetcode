namespace LeetCode.Problems._0341_Flatten_Nested_List_Iterator;

[UsedImplicitly]
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

    public int GetInteger() => IsInteger() ? _value : 0;

    public IList<NestedInteger>? GetList() => !IsInteger() ? _values : null;

    public static IList<NestedInteger> Create(IEnumerable<object> intOrArrayValues) => intOrArrayValues.Select(Create).ToArray();

    private static NestedInteger Create(object intOrArray)
    {
        if (intOrArray is object[] array)
        {
            return new NestedIntegerImpl(Create(array).ToArray());
        }

        return new NestedIntegerImpl(Convert.ToInt32(intOrArray));
    }
}
