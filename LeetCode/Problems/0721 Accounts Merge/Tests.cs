namespace LeetCode.Problems._0721_Accounts_Merge;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.AccountsMerge(testCase.Accounts), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Accounts { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
