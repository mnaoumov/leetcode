// ReSharper disable All
#pragma warning disable
#pragma warning disable
namespace LeetCode._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/205283103/
/// </summary>
public class NestedIterator1 : INestedIterator
{
    private readonly IList<NestedInteger> _nestedList;
    private int _index;
    private NestedIterator1 _innerIterator;

    public NestedIterator1(IList<NestedInteger> nestedList)
    {
        _nestedList = nestedList;
        _index = 0;
    }

    public bool HasNext()
    {
        return _innerIterator != null && _innerIterator.HasNext() || _index < _nestedList.Count;
    }

    public int Next()
    {
        while (true)
        {
            if (_innerIterator != null && _innerIterator.HasNext())
            {
                return _innerIterator.Next();
            }

            _innerIterator = null;

            if (_index == _nestedList.Count)
            {
                throw new InvalidOperationException();
            }

            var nestedInteger = _nestedList[_index];
            _index++;
            if (nestedInteger.IsInteger())
            {
                return nestedInteger.GetInteger();
            }

            _innerIterator = new NestedIterator1(nestedInteger.GetList());
        }
    }
}
