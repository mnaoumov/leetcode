namespace LeetCode.Problems._1152_Analyze_User_Website_Visit_Pattern;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MostVisitedPattern(testCase.Username, testCase.Timestamp, testCase.Website), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Username { get; [UsedImplicitly] init; } = null!;
        public int[] Timestamp { get; [UsedImplicitly] init; } = null!;
        public string[] Website { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
