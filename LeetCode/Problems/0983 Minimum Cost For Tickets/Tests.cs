namespace LeetCode.Problems._0983_Minimum_Cost_For_Tickets;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MincostTickets(testCase.Days, testCase.Costs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Days { get; [UsedImplicitly] init; } = null!;
        public int[] Costs { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
