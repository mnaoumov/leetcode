using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._1230_Toss_Strange_Coins;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ProbabilityOfHeads(testCase.Prob, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public double[] Prob { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }
    }
}
