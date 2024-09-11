namespace LeetCode.Problems._0235_Lowest_Common_Ancestor_of_a_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = TreeNode.Create(testCase.Root);
        var p = root.FindNode(testCase.P)!;
        var q = root.FindNode(testCase.Q)!;
        var output = root.FindNode(testCase.Output)!;
        Assert.That(solution.LowestCommonAncestor(root, p, q), Is.EqualTo(output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int P { get; [UsedImplicitly] init; }
        public int Q { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
