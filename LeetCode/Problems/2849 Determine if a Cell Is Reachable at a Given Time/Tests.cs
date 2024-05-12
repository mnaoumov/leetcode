using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2849_Determine_if_a_Cell_Is_Reachable_at_a_Given_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsReachableAtTime(testCase.Sx, testCase.Sy, testCase.Fx, testCase.Fy, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Sx { get; [UsedImplicitly] init; }
        public int Sy { get; [UsedImplicitly] init; }
        public int Fx { get; [UsedImplicitly] init; }
        public int Fy { get; [UsedImplicitly] init; }
        public int T { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
