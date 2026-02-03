namespace LeetCode.Problems._0272_Closest_Binary_Search_Tree_Value_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.ClosestKValues(TreeNode.Create(testCase.Root), testCase.Target, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int?[] Root { get; [UsedImplicitly] init; } = null!;
        public double Target { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
