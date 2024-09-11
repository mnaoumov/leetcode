namespace LeetCode.Problems._0437_Path_Sum_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PathSum(TreeNode.CreateOrNull(testCase.Root), testCase.TargetSum), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int TargetSum { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
