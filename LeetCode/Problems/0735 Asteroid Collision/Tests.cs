namespace LeetCode.Problems._0735_Asteroid_Collision;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AsteroidCollision(testCase.Asteroids), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Asteroids { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
