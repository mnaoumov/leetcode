namespace LeetCode.Problems._0865_Smallest_Subtree_with_all_the_Deepest_Nodes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SubtreeWithAllDeepest(TreeNode.Create(testCase.Root)), Is.EqualTo(TreeNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
