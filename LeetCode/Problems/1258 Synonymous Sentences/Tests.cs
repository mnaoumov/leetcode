
using JetBrains.Annotations;

namespace LeetCode.Problems._1258_Synonymous_Sentences;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GenerateSentences(testCase.Synonyms, testCase.Text), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Synonyms { get; [UsedImplicitly] init; } = null!;
        public string Text { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
