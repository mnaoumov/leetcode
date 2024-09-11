using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2093_Minimum_Cost_to_Reach_City_With_Discounts;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.N, testCase.Highways, testCase.Discounts), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Highways { get; [UsedImplicitly] init; } = null!;
        public int Discounts { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
