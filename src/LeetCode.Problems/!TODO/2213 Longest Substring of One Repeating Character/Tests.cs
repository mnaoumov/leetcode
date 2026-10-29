namespace LeetCode.Problems._2213_Longest_Substring_of_One_Repeating_Character;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LongestRepeating(testCase.S, testCase.QueryCharacters, testCase.QueryIndices), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string QueryCharacters { get; [UsedImplicitly] init; } = null!;
        public int[] QueryIndices { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
