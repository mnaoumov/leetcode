namespace LeetCode.Problems._1971_Find_if_Path_Exists_in_Graph;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ValidPath(testCase.N, testCase.Edges, testCase.Source, testCase.Destination), Is.EqualTo(testCase.Output));
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
