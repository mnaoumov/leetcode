using NUnit.Framework;

namespace LeetCode._0124_Binary_Tree_Maximum_Path_Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution, Is.Not.Null);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Return = "foo",
                    TestCaseName = "Example 1"
                };
            }
        }
    }
}