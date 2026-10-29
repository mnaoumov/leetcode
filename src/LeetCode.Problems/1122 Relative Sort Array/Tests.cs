namespace LeetCode.Problems._1122_Relative_Sort_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RelativeSortArray(testCase.Arr1, testCase.Arr2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr1 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr2 { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
