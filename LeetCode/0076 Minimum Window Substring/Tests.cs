using NUnit.Framework;

namespace LeetCode._0076_Minimum_Window_Substring;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinWindow(testCase.S, testCase.T), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string T { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "ADOBECODEBANC",
                    T = "ABC",
                    Return = "BANC",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "A",
                    T = "A",
                    Return = "A",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "A",
                    T = "AA",
                    Return = "",
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "a",
                    T = "aa",
                    Return = "",
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}