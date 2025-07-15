namespace LeetCode.Problems._0425_Word_Squares;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.WordSquares(testCase.Words), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
