namespace LeetCode.Problems._1813_Sentence_Similarity_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AreSentencesSimilar(testCase.Sentence1, testCase.Sentence2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Sentence1 { get; [UsedImplicitly] init; } = null!;
        public string Sentence2 { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
