using NUnit.Framework;

namespace LeetCode._0689_Maximum_Sum_of_3_Non_Overlapping_Subarrays;

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