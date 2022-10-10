using NUnit.Framework;

namespace LeetCode._0066_Plus_One;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.PlusOne(testCase.Digits), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Digits { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Digits = new[] { 1, 2, 3 },
                    Output = new[] { 1, 2, 4 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Digits = new[] { 4, 3, 2, 1 },
                    Output = new[] { 4, 3, 2, 2 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Digits = new[] { 9 },
                    Output = new[] { 1, 0 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}