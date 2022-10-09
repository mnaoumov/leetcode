using NUnit.Framework;

namespace LeetCode._0279_Perfect_Squares;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumSquares(testCase.N), Is.EqualTo(testCase.Return));
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
                    N = 12,
                    Return = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 13,
                    Return = 2,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}