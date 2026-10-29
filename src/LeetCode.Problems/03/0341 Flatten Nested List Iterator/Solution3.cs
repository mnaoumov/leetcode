namespace LeetCode.Problems._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/882116786/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public INestedIterator Create(IList<NestedInteger> nestedList)
    {
        return new NestedIterator3(nestedList);
    }
}
