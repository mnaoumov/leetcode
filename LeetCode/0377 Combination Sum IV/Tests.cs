using NUnit.Framework;

namespace LeetCode._0377_Combination_Sum_IV;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CombinationSum4(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3 },
                    Target = 4,
                    Return = 7,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 9 },
                    Target = 3,
                    Return = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}