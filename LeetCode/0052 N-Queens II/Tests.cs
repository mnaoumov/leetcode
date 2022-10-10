using NUnit.Framework;

namespace LeetCode._0052_N_Queens_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TotalNQueens(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 4,
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}