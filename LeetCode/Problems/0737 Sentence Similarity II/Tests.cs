namespace LeetCode.Problems._0737_Sentence_Similarity_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AreSentencesSimilarTwo(testCase.Sentence1, testCase.Sentence2, testCase.SimilarPairs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Sentence1 { get; [UsedImplicitly] init; } = null!;
        public string[] Sentence2 { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> SimilarPairs { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
