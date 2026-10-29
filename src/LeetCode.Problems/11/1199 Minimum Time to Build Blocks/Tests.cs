namespace LeetCode.Problems._1199_Minimum_Time_to_Build_Blocks;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinBuildTime(testCase.Blocks, testCase.Split), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Blocks { get; [UsedImplicitly] init; } = null!;
        public int Split { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
