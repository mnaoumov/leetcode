using NUnit.Framework;

namespace LeetCode._0967_Numbers_With_Same_Consecutive_Differences;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution, Is.Not.Null);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Output = "foo",
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}