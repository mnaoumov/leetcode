namespace LeetCode.Problems._0649_Dota2_Senate;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PredictPartyVictory(testCase.Senate), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Senate { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
