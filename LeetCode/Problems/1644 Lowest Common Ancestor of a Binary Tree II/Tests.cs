namespace LeetCode.Problems._1644_Lowest_Common_Ancestor_of_a_Binary_Tree_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Root);
        var p = root.FindNode(testCase.P) ?? new TreeNode(testCase.P);
        var q = root.FindNode(testCase.Q) ?? new TreeNode(testCase.Q);
        var output = testCase.Output == null ? null : root.FindNode(testCase.Output.Value);
        Assert.That(solution.LowestCommonAncestor(root, p, q), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int Q { get; [UsedImplicitly] init; }
        public int? Output { get; [UsedImplicitly] init; }
    }
}
