namespace LeetCode.Problems._0787_Cheapest_Flights_Within_K_Stops;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindCheapestPrice(testCase.N, testCase.Flights, testCase.Src, testCase.Dst, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Flights { get; [UsedImplicitly] init; } = null!;
        public int Src { get; [UsedImplicitly] init; }
        public int Dst { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
