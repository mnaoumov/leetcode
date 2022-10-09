using NUnit.Framework;

namespace LeetCode._0122_Best_Time_to_Buy_and_Sell_Stock_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProfit(testCase.Prices), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Prices { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Prices = new[] { 7, 1, 5, 3, 6, 4 },
                    Return = 7,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Prices = new[] { 1, 2, 3, 4, 5 },
                    Return = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Prices = new[] { 7, 6, 4, 3, 1 },
                    Return = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}