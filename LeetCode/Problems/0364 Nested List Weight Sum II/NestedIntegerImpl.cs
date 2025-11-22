namespace LeetCode.Problems._0364_Nested_List_Weight_Sum_II;

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

    public int GetInteger() => IsInteger() ? _value : default;

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
