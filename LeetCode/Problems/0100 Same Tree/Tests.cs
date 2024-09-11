namespace LeetCode.Problems._0100_Same_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsSameTree(TreeNode.Create(testCase.PValues), TreeNode.Create(testCase.QValues)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] PValues { get; [UsedImplicitly] init; } = null!;
        public int?[] QValues { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
