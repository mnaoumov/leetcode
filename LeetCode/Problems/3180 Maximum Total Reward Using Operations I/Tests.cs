using JetBrains.Annotations;
using LeetCode.Base;
using NUnit.Framework;

namespace LeetCode.Problems._3180_Maximum_Total_Reward_Using_Operations_I;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxTotalReward(testCase.RewardValues), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] RewardValues { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
