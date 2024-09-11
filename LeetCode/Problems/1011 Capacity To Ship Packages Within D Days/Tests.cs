namespace LeetCode.Problems._1011_Capacity_To_Ship_Packages_Within_D_Days;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ShipWithinDays(testCase.Weights, testCase.Days), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Weights { get; [UsedImplicitly] init; } = null!;
        public int Days { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
