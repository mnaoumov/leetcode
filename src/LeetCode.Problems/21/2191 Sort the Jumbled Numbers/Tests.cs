namespace LeetCode.Problems._2191_Sort_the_Jumbled_Numbers;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SortJumbled(testCase.Mapping, testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Mapping { get; [UsedImplicitly] init; } = null!;
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
