namespace LeetCode.Problems._2333_Minimum_Sum_of_Squared_Difference;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinSumSquareDiff(testCase.Nums1, testCase.Nums2, testCase.K1, testCase.K2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int K1 { get; [UsedImplicitly] init; }
        public int K2 { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
