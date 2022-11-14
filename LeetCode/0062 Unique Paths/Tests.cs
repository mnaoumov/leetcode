using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0062_Unique_Paths;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.UniquePaths(testCase.M, testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    M = 3,
                    N = 7,
                    Output = 28,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    M = 3,
                    N = 2,
                    Output = 3,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}