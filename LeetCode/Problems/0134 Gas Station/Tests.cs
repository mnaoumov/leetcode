using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode.Problems._0134_Gas_Station;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CanCompleteCircuit(testCase.Gas, testCase.Cost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Gas { get; [UsedImplicitly] init; } = null!;
        public int[] Cost { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
