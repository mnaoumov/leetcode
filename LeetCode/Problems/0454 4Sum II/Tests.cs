using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0454_4Sum_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FourSumCount(testCase.Nums1, testCase.Nums2, testCase.Nums3, testCase.Nums4),
            Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums3 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums4 { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
