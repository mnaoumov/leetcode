using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._2139_Minimum_Moves_to_Reach_Target_Score;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMoves(testCase.Target, testCase.MaxDoubles), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Target { get; [UsedImplicitly] init; }
        public int MaxDoubles { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
