namespace LeetCode.Problems._0370_Range_Addition;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetModifiedArray(testCase.Length, testCase.Updates), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int Length { get; [UsedImplicitly] init; }
        public int[][] Updates { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
