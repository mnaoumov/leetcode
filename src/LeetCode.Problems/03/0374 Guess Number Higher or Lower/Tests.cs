namespace LeetCode.Problems._0374_Guess_Number_Higher_or_Lower;

[UsedImplicitly]
public class Tests : TestsBase<GuessGame, Tests.TestCase>
{
    protected override void TestCore(GuessGame solution, TestCase testCase)
    {
        solution.SetPick(testCase.Pick);
        Assert.That(solution.GuessNumber(testCase.N), Is.EqualTo(testCase.Pick));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int Pick { get; [UsedImplicitly] init; }
    }
}
