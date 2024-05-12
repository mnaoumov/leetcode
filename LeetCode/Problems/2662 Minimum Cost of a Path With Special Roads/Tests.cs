using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._2662_Minimum_Cost_of_a_Path_With_Special_Roads;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.Start, testCase.Target, testCase.SpecialRoads), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Start { get; [UsedImplicitly] init; } = null!;
        public int[] Target { get; [UsedImplicitly] init; } = null!;
        public int[][] SpecialRoads { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
