namespace LeetCode.Problems._0341_Flatten_Nested_List_Iterator;

/// <seealso href="https://leetcode.com/submissions/detail/205283103/">Submission</seealso>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INestedIterator Create(IList<NestedInteger> nestedList)
    {
        return new NestedIterator1(nestedList);
    }
}
