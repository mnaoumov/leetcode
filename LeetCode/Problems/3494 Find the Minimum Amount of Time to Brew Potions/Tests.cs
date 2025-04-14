namespace LeetCode.Problems._3494_Find_the_Minimum_Amount_of_Time_to_Brew_Potions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinTime(testCase.Skill, testCase.Mana), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Skill { get; [UsedImplicitly] init; } = null!;
        public int[] Mana { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
