namespace LeetCode.Problems._1900_The_Earliest_and_Latest_Rounds_Where_Players_Compete;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.EarliestAndLatest(testCase.N, testCase.FirstPlayer, testCase.SecondPlayer), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int FirstPlayer { get; [UsedImplicitly] init; }
        public int SecondPlayer { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
