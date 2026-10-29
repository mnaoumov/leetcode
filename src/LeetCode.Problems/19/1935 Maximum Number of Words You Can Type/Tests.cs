namespace LeetCode.Problems._1935_Maximum_Number_of_Words_You_Can_Type;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanBeTypedWords(testCase.Text, testCase.BrokenLetters), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Text { get; [UsedImplicitly] init; } = null!;
        public string BrokenLetters { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
