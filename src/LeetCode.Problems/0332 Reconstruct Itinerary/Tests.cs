namespace LeetCode.Problems._0332_Reconstruct_Itinerary;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindItinerary(testCase.Tickets), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<string>> Tickets { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
