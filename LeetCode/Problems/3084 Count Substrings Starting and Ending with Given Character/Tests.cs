namespace LeetCode.Problems._3084_Count_Substrings_Starting_and_Ending_with_Given_Character;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubstrings(testCase.S, testCase.C), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public char C { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
