namespace LeetCode.Problems._0774_Minimize_Max_Distance_to_Gas_Station;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinmaxGasDist(testCase.Stations, testCase.K), Is.EqualTo(testCase.Output).Within(1e-6));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Stations { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
