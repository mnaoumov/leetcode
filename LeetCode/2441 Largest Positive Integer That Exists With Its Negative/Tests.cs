using NUnit.Framework;

namespace LeetCode._2441_Largest_Positive_Integer_That_Exists_With_Its_Negative;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindMaxK(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { -1, 2, -3, 3 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { -1, 10, 6, 7, -7, 1 },
                    Output = 7,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { -10, 8, 6, 7, -2, -3 },
                    Output = -1,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}