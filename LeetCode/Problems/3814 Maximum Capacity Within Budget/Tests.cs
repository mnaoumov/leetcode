namespace LeetCode.Problems._3814_Maximum_Capacity_Within_Budget;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxCapacity(testCase.Costs, testCase.Capacity, testCase.Budget), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Costs { get; [UsedImplicitly] init; } = null!;
        public int[] Capacity { get; [UsedImplicitly] init; } = null!;
        public int Budget { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
