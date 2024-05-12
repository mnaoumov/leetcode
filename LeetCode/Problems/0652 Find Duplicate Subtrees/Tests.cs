
using JetBrains.Annotations;

namespace LeetCode.Problems._0652_Find_Duplicate_Subtrees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var actualSerializedSubtrees = solution.FindDuplicateSubtrees(TreeNode.Create(testCase.Root)).Select(subtree => subtree.ToString());
        var expectedSerializedSubtrees = testCase.Output.Select(values => TreeNode.Create(values).ToString());
        AssertCollectionEquivalentWithDetails(actualSerializedSubtrees, expectedSerializedSubtrees);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public IList<int?[]> Output { get; [UsedImplicitly] init; } = null!;
    }
}
