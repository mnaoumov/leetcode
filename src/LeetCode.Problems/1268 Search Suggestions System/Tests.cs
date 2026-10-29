namespace LeetCode.Problems._1268_Search_Suggestions_System;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SuggestedProducts(testCase.Products, testCase.SearchWord), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Products { get; [UsedImplicitly] init; } = null!;
        public string SearchWord { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
