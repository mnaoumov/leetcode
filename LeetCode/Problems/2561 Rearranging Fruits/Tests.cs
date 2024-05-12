using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2561_Rearranging_Fruits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.Basket1, testCase.Basket2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Basket1 { get; [UsedImplicitly] init; } = null!;
        public int[] Basket2 { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
