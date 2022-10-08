using NUnit.Framework;

namespace LeetCode._0114_Flatten_Binary_Tree_to_Linked_List;

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