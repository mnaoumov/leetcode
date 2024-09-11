using NUnit.Framework;
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1473_Paint_House_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.Houses, testCase.Cost, testCase.M, testCase.N, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Houses { get; [UsedImplicitly] init; } = null!;
        public int[][] Cost { get; [UsedImplicitly] init; } = null!;
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
