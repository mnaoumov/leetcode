namespace LeetCode.Problems._1606_Find_Servers_That_Handled_Most_Number_of_Requests;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BusiestServers(testCase.K, testCase.Arrival, testCase.Load), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int[] Arrival { get; [UsedImplicitly] init; } = null!;
        public int[] Load { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
