namespace LeetCode.Problems._1578_Minimum_Time_to_Make_Rope_Colorful;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.Colors, testCase.NeededTime), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Colors { get; [UsedImplicitly] init; } = null!;
        public int[] NeededTime { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
