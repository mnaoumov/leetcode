using NUnit.Framework;

using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0322_Coin_Change;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CoinChange(testCase.Coins, testCase.Amount), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int Amount { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
