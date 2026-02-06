namespace LeetCode.Problems._1792_Maximum_Average_Pass_Ratio;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxAverageRatio(testCase.Classes, testCase.ExtraStudents), Is.EqualTo(testCase.Output).Within(1e-5));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Classes { get; [UsedImplicitly] init; } = null!;
        public int ExtraStudents { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
