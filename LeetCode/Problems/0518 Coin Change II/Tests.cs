using NUnit.Framework;
using JetBrains.Annotations;

namespace LeetCode._0518_Coin_Change_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Change(testCase.Amount, testCase.Coins), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Amount { get; [UsedImplicitly] init; }
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
