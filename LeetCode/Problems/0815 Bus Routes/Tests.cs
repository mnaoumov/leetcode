using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0815_Bus_Routes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumBusesToDestination(testCase.Routes, testCase.Source, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Routes { get; [UsedImplicitly] init; } = null!;
        public int Source { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
