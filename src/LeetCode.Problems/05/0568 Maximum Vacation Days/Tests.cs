namespace LeetCode.Problems._0568_Maximum_Vacation_Days;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxVacationDays(testCase.Flights, testCase.Days), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Flights { get; [UsedImplicitly] init; } = null!;
        public int[][] Days { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
