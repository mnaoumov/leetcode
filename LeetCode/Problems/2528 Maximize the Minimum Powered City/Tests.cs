namespace LeetCode.Problems._2528_Maximize_the_Minimum_Powered_City;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPower(testCase.Stations, testCase.R, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Stations { get; [UsedImplicitly] init; } = null!;
        public int R { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
