namespace LeetCode.Problems._2800_Shortest_String_That_Contains_Three_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumString(testCase.A, testCase.B, testCase.C), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string A { get; [UsedImplicitly] init; } = null!;
        public string B { get; [UsedImplicitly] init; } = null!;
        public string C { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
