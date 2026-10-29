namespace LeetCode.Problems._0966_Vowel_Spellchecker;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Spellchecker(testCase.Wordlist, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Wordlist { get; [UsedImplicitly] init; } = null!;
        public string[] Queries { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
