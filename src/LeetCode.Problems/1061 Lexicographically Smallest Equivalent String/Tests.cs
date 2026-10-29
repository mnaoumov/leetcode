namespace LeetCode.Problems._1061_Lexicographically_Smallest_Equivalent_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestEquivalentString(testCase.S1, testCase.S2, testCase.BaseStr), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string S1 { get; [UsedImplicitly] init; } = null!;
        public string S2 { get; [UsedImplicitly] init; } = null!;
        public string BaseStr { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
