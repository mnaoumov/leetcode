namespace LeetCode.Problems._1654_Minimum_Jumps_to_Reach_Home;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumJumps(testCase.Forbidden, testCase.A, testCase.B, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Forbidden { get; [UsedImplicitly] init; } = null!;
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
