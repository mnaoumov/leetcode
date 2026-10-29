namespace LeetCode.Problems._1340_Jump_Game_V;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxJumps(testCase.Arr, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public int D { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
