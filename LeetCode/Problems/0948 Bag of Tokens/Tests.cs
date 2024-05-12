using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0948_Bag_of_Tokens;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BagOfTokensScore(testCase.Tokens, testCase.Power), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Tokens { get; [UsedImplicitly] init; } = null!;
        public int Power { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
