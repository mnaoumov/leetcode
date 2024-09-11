namespace LeetCode.Problems._2739_Total_Distance_Traveled;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DistanceTraveled(testCase.MainTank, testCase.AdditionalTank), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int MainTank { get; [UsedImplicitly] init; }
        public int AdditionalTank { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
