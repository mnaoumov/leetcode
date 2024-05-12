using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._2444_Count_Subarrays_With_Fixed_Bounds;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountSubarrays(testCase.Nums, testCase.MinK, testCase.MaxK), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int MinK { get; [UsedImplicitly] init; }
        public int MaxK { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
