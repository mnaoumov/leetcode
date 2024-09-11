namespace LeetCode.Problems._3207_Maximum_Points_After_Enemy_Battles;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumPoints(testCase.EnemyEnergies, testCase.CurrentEnergy), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] EnemyEnergies { get; [UsedImplicitly] init; } = null!;
        public int CurrentEnergy { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
