namespace LeetCode.Problems._1038_Binary_Search_Tree_to_Greater_Sum_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BstToGst(TreeNode.Create(testCase.Root)), Is.EqualTo(TreeNode.Create(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
