using NUnit.Framework;

namespace LeetCode._0096_Unique_Binary_Search_Trees;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumTrees(testCase.N), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    Return = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    Return = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}