using NUnit.Framework;

namespace LeetCode._0084_Largest_Rectangle_in_Histogram;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LargestRectangleArea(testCase.Heights), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Heights { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Heights = new[] { 2, 1, 5, 6, 2, 3 },
                    Return = 10,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Heights = new[] { 2, 4 },
                    Return = 4,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}