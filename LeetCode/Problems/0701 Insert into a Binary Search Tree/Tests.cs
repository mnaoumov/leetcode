namespace LeetCode.Problems._0701_Insert_into_a_Binary_Search_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.InsertIntoBST(TreeNode.CreateOrNull(testCase.Root), testCase.Val), Is.EqualTo(TreeNode.CreateOrNull(testCase.Output)));
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Val { get; [UsedImplicitly] init; }
        public int?[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
