namespace LeetCode.Problems._1065_Index_Pairs_of_a_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.IndexPairs(testCase.Text, testCase.Words), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Text { get; [UsedImplicitly] init; } = null!;
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
