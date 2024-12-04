namespace LeetCode.Problems._0277_Find_the_Celebrity;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        solution.Init(testCase.Graph);
        Assert.That(solution.FindCelebrity(testCase.Graph.Length), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Graph { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
