using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode.Problems._0846_Hand_of_Straights;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsNStraightHand(testCase.Hand, testCase.GroupSize), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Hand { get; [UsedImplicitly] init; } = null!;
        public int GroupSize { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
