namespace LeetCode.Problems._1967_Number_of_Strings_That_Appear_as_Substrings_in_Word;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumOfStrings(testCase.Patterns, testCase.Word), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Patterns { get; [UsedImplicitly] init; } = null!;
        public string Word { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
