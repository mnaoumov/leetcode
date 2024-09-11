namespace LeetCode.Problems._0088_Merge_Sorted_Array;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var nums1 = testCase.Nums1.ToArray();
        solution.Merge(nums1, testCase.M, testCase.Nums2, testCase.N);
        Assert.That(nums1, Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
