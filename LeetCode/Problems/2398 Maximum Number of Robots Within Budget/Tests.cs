using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2398_Maximum_Number_of_Robots_Within_Budget;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumRobots(testCase.ChargeTimes, testCase.RunningCosts, testCase.Budget), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] ChargeTimes { get; [UsedImplicitly] init; } = null!;
        public int[] RunningCosts { get; [UsedImplicitly] init; } = null!;
        public long Budget { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
