using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1701_Average_Waiting_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AverageWaitingTime(testCase.Customers), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Customers { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
