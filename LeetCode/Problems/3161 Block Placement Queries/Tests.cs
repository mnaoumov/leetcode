namespace LeetCode.Problems._3161_Block_Placement_Queries;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetResults(testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
