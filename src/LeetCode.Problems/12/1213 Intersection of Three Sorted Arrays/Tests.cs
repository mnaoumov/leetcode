namespace LeetCode.Problems._1213_Intersection_of_Three_Sorted_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ArraysIntersection(testCase.Arr1, testCase.Arr2, testCase.Arr3), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr1 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr2 { get; [UsedImplicitly] init; } = null!;
        public int[] Arr3 { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
