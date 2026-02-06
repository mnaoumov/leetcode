namespace LeetCode.Problems._3331_Find_Subtree_Sizes_After_Changes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindSubtreeSizes(testCase.Parent, testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Parent { get; [UsedImplicitly] init; } = null!;
        public string S { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
