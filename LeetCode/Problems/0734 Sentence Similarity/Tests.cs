using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0734_Sentence_Similarity;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AreSentencesSimilar(testCase.Sentence1, testCase.Sentence2, testCase.SimilarPairs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Sentence1 { get; [UsedImplicitly] init; } = null!;
        public string[] Sentence2 { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> SimilarPairs { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
