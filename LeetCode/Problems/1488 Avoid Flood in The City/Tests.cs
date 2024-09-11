namespace LeetCode.Problems._1488_Avoid_Flood_in_The_City;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AvoidFlood(testCase.Rains), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Rains { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
