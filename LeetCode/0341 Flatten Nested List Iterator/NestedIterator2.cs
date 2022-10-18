// ReSharper disable All
#pragma warning disable
namespace LeetCode._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/205283879/
/// </summary>
public class NestedIterator2 : INestedIterator
{
    private readonly IList<NestedInteger> _nestedList;
    private int _index;
    private NestedIterator2 _innerIterator;

    public NestedIterator2(IList<NestedInteger> nestedList)
    {
        _nestedList = nestedList;
        _index = 0;
    }

    public bool HasNext()
    {
        while (true)
        {
            if (_innerIterator != null && _innerIterator.HasNext())
            {
                return true;
            }

            _innerIterator = null;

            if (_index == _nestedList.Count)
            {
                return false;
            }

            var nestedInteger = _nestedList[_index];
            if (nestedInteger.IsInteger())
            {
                return true;
            }

            _innerIterator = new NestedIterator2(nestedInteger.GetList());
            _index++;
        }
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

            NestedInteger nestedInteger = _nestedList[_index];
            _index++;
            if (nestedInteger.IsInteger())
            {
                return nestedInteger.GetInteger();
            }

            _innerIterator = new NestedIterator2(nestedInteger.GetList());
        }
    }
}
