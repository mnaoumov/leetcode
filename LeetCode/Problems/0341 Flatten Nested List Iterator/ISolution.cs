using JetBrains.Annotations;

namespace LeetCode.Problems._0341_Flatten_Nested_List_Iterator;

[PublicAPI]
public interface ISolution
{
    INestedIterator Create(IList<NestedInteger> nestedList);
}
