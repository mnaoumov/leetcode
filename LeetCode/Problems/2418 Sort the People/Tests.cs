namespace LeetCode.Problems._2418_Sort_the_People;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SortPeople(testCase.Names, testCase.Heights), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public string[] Names { get; [UsedImplicitly] init; } = null!;
        public int[] Heights { get; [UsedImplicitly] init; } = null!;
        public string[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
