namespace LeetCode._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/882116786/
/// </summary>
public class NestedIterator3 : INestedIterator
{
    private readonly IEnumerator<int> _enumerator;

    public NestedIterator3(IEnumerable<NestedInteger> nestedList) => _enumerator = Enumerate(nestedList).GetEnumerator();
    private IEnumerable<int> Enumerate(IEnumerable<NestedInteger> nestedList) => nestedList.SelectMany(Enumerate);
    private IEnumerable<int> Enumerate(NestedInteger nestedInteger) => nestedInteger.IsInteger() ? new[] { nestedInteger.GetInteger() } : Enumerate(nestedInteger.GetList()!);

    public bool HasNext() => _enumerator.MoveNext();
    public int Next() => _enumerator.Current;
}