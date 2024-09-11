using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2760_Longest_Even_Odd_Subarray_With_Threshold;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestAlternatingSubarray(testCase.Nums, testCase.Threshold), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Threshold { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
