namespace LeetCode.Problems._2769_Find_the_Maximum_Achievable_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TheMaximumAchievableX(testCase.Num, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Num { get; [UsedImplicitly] init; }
        public int T { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
