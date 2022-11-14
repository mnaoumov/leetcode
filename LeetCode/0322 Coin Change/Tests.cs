﻿using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0322_Coin_Change;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CoinChange(testCase.Coins, testCase.Amount), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int Amount { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}