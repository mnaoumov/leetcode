using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2426_Number_of_Pairs_Satisfying_Inequality;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfPairs(testCase.Nums1, testCase.Nums2, testCase.Diff), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums1 { get; [UsedImplicitly] init; } = null!;
        public int[] Nums2 { get; [UsedImplicitly] init; } = null!;
        public int Diff { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
