namespace LeetCode.Problems._3753_Total_Waviness_of_Numbers_in_Range_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TotalWaviness(testCase.Num1, testCase.Num2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long Num1 { get; [UsedImplicitly] init; }
        public long Num2 { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
