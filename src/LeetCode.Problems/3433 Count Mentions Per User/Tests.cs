namespace LeetCode.Problems._3433_Count_Mentions_Per_User;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CountMentions(testCase.NumberOfUsers, testCase.Events), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int NumberOfUsers { get; [UsedImplicitly] init; }
        public IList<IList<string>> Events { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
