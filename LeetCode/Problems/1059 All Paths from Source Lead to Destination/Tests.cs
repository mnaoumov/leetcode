namespace LeetCode.Problems._1059_All_Paths_from_Source_Lead_to_Destination;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LeadsToDestination(testCase.N, testCase.Edges, testCase.Source, testCase.Destination), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int Source { get; [UsedImplicitly] init; }
        public int Destination { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
