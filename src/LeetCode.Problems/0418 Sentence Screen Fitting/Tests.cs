namespace LeetCode.Problems._0418_Sentence_Screen_Fitting;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.WordsTyping(testCase.Sentence, testCase.Rows, testCase.Cols), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Sentence { get; [UsedImplicitly] init; } = null!;
        public int Rows { get; [UsedImplicitly] init; }
        public int Cols { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
