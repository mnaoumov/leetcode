
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0350_Intersection_of_Two_Arrays_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Intersect(testCase.Nums1, testCase.Nums2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
