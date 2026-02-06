namespace LeetCode.Problems._1710_Maximum_Units_on_a_Truck;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumUnits(testCase.BoxTypes, testCase.TruckSize), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] BoxTypes { get; [UsedImplicitly] init; } = null!;
        public int TruckSize { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
