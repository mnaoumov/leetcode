using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1508_Range_Sum_of_Sorted_Subarray_Sums;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RangeSum(testCase.Nums, testCase.N, testCase.Left, testCase.Right), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int N { get; [UsedImplicitly] init; }
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
