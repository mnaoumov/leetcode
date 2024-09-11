namespace LeetCode.Problems._1514_Path_with_Maximum_Probability;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProbability(testCase.N, testCase.Edges, testCase.SuccProb, testCase.Start, testCase.End), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public double[] SuccProb { get; [UsedImplicitly] init; } = null!;
        public int Start { get; [UsedImplicitly] init; }
        public int End { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
