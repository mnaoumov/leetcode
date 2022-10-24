using JetBrains.Annotations;

namespace LeetCode._0341_Flatten_Nested_List_Iterator;

/// <summary>
/// https://leetcode.com/submissions/detail/205283103/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public INestedIterator Create(IList<NestedInteger> nestedList)
    {
        return new NestedIterator1(nestedList);
    }
}