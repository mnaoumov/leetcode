namespace LeetCode.Problems._0776_Split_BST;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SplitBST(TreeNode.CreateOrNull(testCase.Root), testCase.Target).Select(TreeNode.GetValues), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int?[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
