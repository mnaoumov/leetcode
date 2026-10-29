namespace LeetCode.Problems._1518_Water_Bottles;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumWaterBottles(testCase.NumBottles, testCase.NumExchange), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int NumBottles { get; [UsedImplicitly] init; }
        public int NumExchange { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
