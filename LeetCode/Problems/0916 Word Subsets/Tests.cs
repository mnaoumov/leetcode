namespace LeetCode.Problems._0916_Word_Subsets;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.WordSubsets(testCase.Words1, testCase.Words2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words1 { get; [UsedImplicitly] init; } = null!;
        public string[] Words2 { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
