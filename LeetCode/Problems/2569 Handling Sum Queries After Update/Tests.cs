
using JetBrains.Annotations;

namespace LeetCode.Problems._2569_Handling_Sum_Queries_After_Update;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.HandleQuery(testCase.Nums1, testCase.Nums2, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
