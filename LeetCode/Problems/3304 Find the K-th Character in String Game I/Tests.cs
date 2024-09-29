namespace LeetCode.Problems._3304_Find_the_K_th_Character_in_String_Game_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KthCharacter(testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public char Output { get; [UsedImplicitly] init; }
    }
}
