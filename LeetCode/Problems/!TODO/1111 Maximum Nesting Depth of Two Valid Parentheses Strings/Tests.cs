namespace LeetCode.Problems._1111_Maximum_Nesting_Depth_of_Two_Valid_Parentheses_Strings;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaxDepthAfterSplit(testCase.Seq), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string Seq { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
