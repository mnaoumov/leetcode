namespace LeetCode.Problems._0514_Freedom_Trail;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindRotateSteps(testCase.Ring, testCase.Key), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Ring { get; [UsedImplicitly] init; } = null!;
        public string Key { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
