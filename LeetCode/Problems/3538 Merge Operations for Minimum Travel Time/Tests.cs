namespace LeetCode.Problems._3538_Merge_Operations_for_Minimum_Travel_Time;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinTravelTime(testCase.L, testCase.N, testCase.K, testCase.Position, testCase.Time), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int L { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int[] Position { get; [UsedImplicitly] init; } = null!;
        public int[] Time { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
