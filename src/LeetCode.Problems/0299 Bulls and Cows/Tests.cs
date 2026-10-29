namespace LeetCode.Problems._0299_Bulls_and_Cows;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetHint(testCase.Secret, testCase.Guess), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Secret { get; [UsedImplicitly] init; } = null!;
        public string Guess { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
