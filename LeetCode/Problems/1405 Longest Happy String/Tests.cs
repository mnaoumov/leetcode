namespace LeetCode.Problems._1405_Longest_Happy_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestDiverseString(testCase.A, testCase.B, testCase.C), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int A { get; [UsedImplicitly] init; }
        public int B { get; [UsedImplicitly] init; }
        public int C { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
