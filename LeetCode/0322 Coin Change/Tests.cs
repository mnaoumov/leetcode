using NUnit.Framework;

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

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Coins = new[] { 1, 2, 5 },
                    Amount = 11,
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Coins = new[] { 2 },
                    Amount = 3,
                    Output = -1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Coins = new[] { 1 },
                    Amount = 0,
                    Output = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}