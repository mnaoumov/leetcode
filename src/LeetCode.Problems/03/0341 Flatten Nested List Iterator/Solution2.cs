namespace LeetCode.Problems._0341_Flatten_Nested_List_Iterator;

/// <seealso href="https://leetcode.com/submissions/detail/205283879/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public INestedIterator Create(IList<NestedInteger> nestedList)
    {
        return new NestedIterator2(nestedList);
    }
}
