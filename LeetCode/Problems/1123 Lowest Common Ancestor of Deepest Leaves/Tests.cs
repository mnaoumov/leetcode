namespace LeetCode.Problems._1123_Lowest_Common_Ancestor_of_Deepest_Leaves;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LcaDeepestLeaves(TreeNode.Create(testCase.Root)), Is.EqualTo(TreeNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
