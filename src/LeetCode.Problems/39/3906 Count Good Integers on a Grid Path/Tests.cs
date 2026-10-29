namespace LeetCode.Problems._3906_Count_Good_Integers_on_a_Grid_Path;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountGoodIntegersOnPath(testCase.L, testCase.R, testCase.Directions), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long L { get; [UsedImplicitly] init; }
        public long R { get; [UsedImplicitly] init; }
        public string Directions { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
