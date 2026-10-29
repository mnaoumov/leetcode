namespace LeetCode.Problems._3767_Maximize_Points_After_Choosing_K_Tasks;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPoints(testCase.Technique1, testCase.Technique2, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Technique1 { get; [UsedImplicitly] init; } = null!;
        public int[] Technique2 { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
