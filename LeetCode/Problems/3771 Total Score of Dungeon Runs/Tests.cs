namespace LeetCode.Problems._3771_Total_Score_of_Dungeon_Runs;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TotalScore(testCase.Hp, testCase.Damage, testCase.Requirement), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Hp { get; [UsedImplicitly] init; }
        public int[] Damage { get; [UsedImplicitly] init; } = null!;
        public int[] Requirement { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
