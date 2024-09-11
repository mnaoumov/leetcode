namespace LeetCode.Problems._2126_Destroying_Asteroids;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AsteroidsDestroyed(testCase.Mass, testCase.Asteroids), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Mass { get; [UsedImplicitly] init; }
        public int[] Asteroids { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
