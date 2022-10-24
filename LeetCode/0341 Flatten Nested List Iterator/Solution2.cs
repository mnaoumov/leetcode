using JetBrains.Annotations;

namespace LeetCode._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/205283879/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public INestedIterator Create(IList<NestedInteger> nestedList)
    {
        return new NestedIterator2(nestedList);
    }
}