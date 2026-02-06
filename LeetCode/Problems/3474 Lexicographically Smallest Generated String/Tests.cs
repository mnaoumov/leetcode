namespace LeetCode.Problems._3474_Lexicographically_Smallest_Generated_String;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateString(testCase.Str1, testCase.Str2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Str1 { get; [UsedImplicitly] init; } = null!;
        public string Str2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
