using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._1232_Check_If_It_Is_a_Straight_Line;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckStraightLine(testCase.Coordinates), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Coordinates { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
