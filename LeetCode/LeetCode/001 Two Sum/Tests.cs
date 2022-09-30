using NUnit.Framework;

namespace LeetCode._001_Two_Sum;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TwoSum(testCase.Nums, testCase.Target), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; init; }
        public int Target { get; init; }
        public int[] ExpectedResult { get; init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 7, 11, 15 },
                    Target = 9,
                    ExpectedResult = new[] { 0, 1 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 2, 4, 6 },
                    Target = 6,
                    ExpectedResult = new[] { 1, 2 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 3 },
                    Target = 6,
                    ExpectedResult = new[] { 0, 1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}