namespace LeetCode.Problems._2211_Count_Collisions_on_a_Road;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountCollisions(testCase.Directions), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Directions { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
