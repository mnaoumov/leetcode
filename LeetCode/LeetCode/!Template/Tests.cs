using NUnit.Framework;

namespace LeetCode._Template;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution, Is.Not.Null);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string ExpectedResult { get; init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}