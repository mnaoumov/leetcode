using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._3013_Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

[UsedImplicitly]
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
