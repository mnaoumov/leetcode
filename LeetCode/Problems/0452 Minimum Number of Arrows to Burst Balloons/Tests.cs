using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0452_Minimum_Number_of_Arrows_to_Burst_Balloons;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMinArrowShots(testCase.Points), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Points { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
