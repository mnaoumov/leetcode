using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0309_Best_Time_to_Buy_and_Sell_Stock_with_Cooldown;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.Prices), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Prices = new[] { 1, 2, 3, 0, 2 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Prices = new[] { 1 },
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
