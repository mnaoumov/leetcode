using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2918_Minimum_Equal_Sum_of_Two_Arrays_After_Replacing_Zeros;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinSum(testCase.Nums1, testCase.Nums2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
