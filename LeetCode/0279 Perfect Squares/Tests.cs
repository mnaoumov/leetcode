using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0279_Perfect_Squares;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumSquares(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 12,
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 13,
                    Output = 2,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}