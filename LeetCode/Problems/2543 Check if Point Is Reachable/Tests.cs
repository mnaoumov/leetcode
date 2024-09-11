using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._2543_Check_if_Point_Is_Reachable;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsReachable(testCase.TargetX, testCase.TargetY), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int TargetX { get; [UsedImplicitly] init; }
        public int TargetY { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
