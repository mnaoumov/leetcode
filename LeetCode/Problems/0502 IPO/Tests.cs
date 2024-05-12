using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode.Problems._0502_IPO;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaximizedCapital(testCase.K, testCase.W, testCase.Profits, testCase.Capital), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int W { get; [UsedImplicitly] init; }
        public int[] Profits { get; [UsedImplicitly] init; } = null!;
        public int[] Capital { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
