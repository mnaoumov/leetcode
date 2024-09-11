using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3013_Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.Nums, testCase.K, testCase.Dist), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Dist { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
