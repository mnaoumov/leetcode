namespace LeetCode.Problems._0429_N_ary_Tree_Level_Order_Traversal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = Node.CreateOrNull(testCase.Root);
        AssertCollectionEqualWithDetails(solution.LevelOrder(root), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
