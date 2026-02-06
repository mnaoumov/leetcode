namespace LeetCode.Problems._3419_Minimize_the_Maximum_Edge_Weight_of_Graph;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMaxWeight(testCase.N, testCase.Edges, testCase.Threshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
