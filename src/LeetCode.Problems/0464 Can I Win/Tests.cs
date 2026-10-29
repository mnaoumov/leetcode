namespace LeetCode.Problems._0464_Can_I_Win;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanIWin(testCase.MaxChoosableInteger, testCase.DesiredTotal), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int MaxChoosableInteger { get; [UsedImplicitly] init; }
        public int DesiredTotal { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
