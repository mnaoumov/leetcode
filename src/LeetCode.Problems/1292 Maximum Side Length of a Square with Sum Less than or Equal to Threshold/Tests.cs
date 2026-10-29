namespace LeetCode.Problems._1292_Maximum_Side_Length_of_a_Square_with_Sum_Less_than_or_Equal_to_Threshold;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSideLength(testCase.Mat, testCase.Threshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
