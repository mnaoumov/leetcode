namespace LeetCode.Problems._2586_Count_the_Number_of_Vowel_Strings_in_Range;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.VowelStrings(testCase.Words, testCase.Left, testCase.Right), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
