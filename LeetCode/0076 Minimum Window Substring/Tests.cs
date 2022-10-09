using NUnit.Framework;

namespace LeetCode._0076_Minimum_Window_Substring;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinWindow(testCase.S, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string T { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "ADOBECODEBANC",
                    T = "ABC",
                    Output = "BANC",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "A",
                    T = "A",
                    Output = "A",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "A",
                    T = "AA",
                    Output = "",
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "a",
                    T = "aa",
                    Output = "",
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}