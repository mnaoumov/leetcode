namespace LeetCode.Problems._3286_Find_a_Safe_Walk_Through_a_Grid;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindSafeWalk(testCase.Grid, testCase.Health), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public IList<IList<int>> Grid { get; [UsedImplicitly] init; } = null!;
        public int Health { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
