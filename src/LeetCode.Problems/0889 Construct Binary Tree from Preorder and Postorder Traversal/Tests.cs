namespace LeetCode.Problems._0889_Construct_Binary_Tree_from_Preorder_and_Postorder_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ConstructFromPrePost(testCase.Preorder, testCase.Postorder), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Preorder { get; [UsedImplicitly] init; } = null!;
        public int[] Postorder { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
