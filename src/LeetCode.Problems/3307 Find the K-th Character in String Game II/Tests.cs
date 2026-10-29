namespace LeetCode.Problems._3307_Find_the_K_th_Character_in_String_Game_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.KthCharacter(testCase.K, testCase.Operations), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public long K { get; [UsedImplicitly] init; }
        public int[] Operations { get; [UsedImplicitly] init; } = null!;
        public char Output { get; [UsedImplicitly] init; }
    }
}
