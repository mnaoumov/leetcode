namespace LeetCode.Problems._0744_Find_Smallest_Letter_Greater_Than_Target;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NextGreatestLetter(testCase.Letters, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public char[] Letters { get; [UsedImplicitly] init; } = null!;
        public char Target { get; [UsedImplicitly] init; }
        public char Output { get; [UsedImplicitly] init; }
    }
}
