namespace LeetCode.Problems._2900_Longest_Unequal_Adjacent_Groups_Subsequence_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetWordsInLongestSubsequence(testCase.N, testCase.Words, testCase.Groups), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int[] Groups { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;
    }
}
