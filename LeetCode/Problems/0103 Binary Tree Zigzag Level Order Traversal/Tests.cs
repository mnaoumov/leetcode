namespace LeetCode.Problems._0103_Binary_Tree_Zigzag_Level_Order_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ZigzagLevelOrder(TreeNode.CreateOrNull(testCase.RootValues)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] RootValues { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
