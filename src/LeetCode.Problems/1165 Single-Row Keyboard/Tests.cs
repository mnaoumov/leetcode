namespace LeetCode.Problems._1165_Single_Row_Keyboard;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CalculateTime(testCase.Keyboard, testCase.Word), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Keyboard { get; [UsedImplicitly] init; } = null!;
        public string Word { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
