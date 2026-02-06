namespace LeetCode.Problems._2469_Convert_the_Temperature;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ConvertTemperature(testCase.Celsius), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public double Celsius { get; [UsedImplicitly] init; }
        public double[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
