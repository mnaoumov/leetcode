namespace LeetCode.Problems._0951_Flip_Equivalent_Binary_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FlipEquiv(TreeNode.CreateOrNull(testCase.Root1), TreeNode.CreateOrNull(testCase.Root2)), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root1 { get; [UsedImplicitly] init; } = null!;
        public int?[] Root2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
