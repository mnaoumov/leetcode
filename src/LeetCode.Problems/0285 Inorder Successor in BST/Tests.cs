namespace LeetCode.Problems._0285_Inorder_Successor_in_BST;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var tree = TreeNode.Create(testCase.Root);
        var p = tree.FindNode(testCase.P);
        Assert.That(p, Is.Not.Null);
        var output = testCase.Output == null ? null : tree.FindNode(testCase.Output.Value);
        Assert.That(solution.InorderSuccessor(tree, p!), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int? Output { get; [UsedImplicitly] init; } = null!;
    }
}
