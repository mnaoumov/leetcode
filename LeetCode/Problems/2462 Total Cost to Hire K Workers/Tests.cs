namespace LeetCode.Problems._2462_Total_Cost_to_Hire_K_Workers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TotalCost(testCase.Costs, testCase.K, testCase.Candidates), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Costs { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Candidates { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
