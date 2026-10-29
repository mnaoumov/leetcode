namespace LeetCode.Problems._0156_Binary_Tree_Upside_Down;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.UpsideDownBinaryTree(TreeNode.CreateOrNull(testCase.Root)), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
