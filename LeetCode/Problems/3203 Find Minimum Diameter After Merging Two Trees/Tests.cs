namespace LeetCode.Problems._3203_Find_Minimum_Diameter_After_Merging_Two_Trees;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumDiameterAfterMerge(testCase.Edges1, testCase.Edges2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Edges1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Edges2 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
