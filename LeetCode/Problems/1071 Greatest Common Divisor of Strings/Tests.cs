namespace LeetCode.Problems._1071_Greatest_Common_Divisor_of_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GcdOfStrings(testCase.Str1, testCase.Str2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Str1 { get; [UsedImplicitly] init; } = null!;
        public string Str2 { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
