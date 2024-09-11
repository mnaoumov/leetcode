namespace LeetCode.Problems._2477_Minimum_Fuel_Cost_to_Report_to_the_Capital;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumFuelCost(testCase.Roads, testCase.Seats), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Roads { get; [UsedImplicitly] init; } = null!;
        public int Seats { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
