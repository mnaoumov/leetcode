namespace LeetCode.Problems._3522_Calculate_Score_After_Performing_Instructions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CalculateScore(testCase.Instructions, testCase.Values), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Instructions { get; [UsedImplicitly] init; } = null!;
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
