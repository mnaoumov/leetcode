namespace LeetCode.Problems._3273_Minimum_Amount_of_Damage_Dealt_to_Bob;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDamage(testCase.Power, testCase.Damage, testCase.Health), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Power { get; [UsedImplicitly] init; }
        public int[] Damage { get; [UsedImplicitly] init; } = null!;
        public int[] Health { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
