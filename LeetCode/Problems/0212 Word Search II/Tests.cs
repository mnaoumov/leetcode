namespace LeetCode.Problems._0212_Word_Search_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.FindWords(testCase.Board, testCase.Words), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
