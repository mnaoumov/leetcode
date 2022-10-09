using NUnit.Framework;

namespace LeetCode._0084_Largest_Rectangle_in_Histogram;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LargestRectangleArea(testCase.Heights), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Heights { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Heights = new[] { 2, 1, 5, 6, 2, 3 },
                    Output = 10,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Heights = new[] { 2, 4 },
                    Output = 4,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}