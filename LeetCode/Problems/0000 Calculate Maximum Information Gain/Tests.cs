namespace LeetCode.Problems._0000_Calculate_Maximum_Information_Gain;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CalculateMaxInfoGain(testCase.Petal_length, testCase.Species), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        // ReSharper disable once InconsistentNaming
        public double[] Petal_length { get; [UsedImplicitly] init; } = null!;
        public string[] Species { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
