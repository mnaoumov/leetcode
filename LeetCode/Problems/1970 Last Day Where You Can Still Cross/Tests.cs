using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1970_Last_Day_Where_You_Can_Still_Cross;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LatestDayToCross(testCase.Row, testCase.Col, testCase.Cells), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Row { get; [UsedImplicitly] init; }
        public int Col { get; [UsedImplicitly] init; }
        public int[][] Cells { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
