namespace LeetCode.Problems._1189_Maximum_Number_of_Balloons;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxNumberOfBalloons(testCase.Text), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Text { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
