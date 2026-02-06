namespace LeetCode.Problems._1325_Delete_Leaves_With_a_Given_Value;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RemoveLeafNodes(TreeNode.Create(testCase.Root), testCase.Target), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
