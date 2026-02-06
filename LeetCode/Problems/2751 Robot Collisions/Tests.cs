namespace LeetCode.Problems._2751_Robot_Collisions;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SurvivedRobotsHealths(testCase.Positions, testCase.Healths, testCase.Directions), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Positions { get; [UsedImplicitly] init; } = null!;
        public int[] Healths { get; [UsedImplicitly] init; } = null!;
        public string Directions { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
