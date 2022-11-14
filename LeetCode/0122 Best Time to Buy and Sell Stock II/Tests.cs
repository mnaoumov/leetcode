using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0122_Best_Time_to_Buy_and_Sell_Stock_II;

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
                    Prices = new[] { 7, 1, 5, 3, 6, 4 },
                    Output = 7,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Prices = new[] { 1, 2, 3, 4, 5 },
                    Output = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Prices = new[] { 7, 6, 4, 3, 1 },
                    Output = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}