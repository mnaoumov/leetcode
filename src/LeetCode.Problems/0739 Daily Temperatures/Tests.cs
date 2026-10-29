namespace LeetCode.Problems._0739_Daily_Temperatures;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.DailyTemperatures(testCase.Temperatures), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Temperatures { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
