using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2585_Number_of_Ways_to_Earn_Points;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.WaysToReachTarget(testCase.Target, testCase.Types), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Target { get; [UsedImplicitly] init; }
        public int[][] Types { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
