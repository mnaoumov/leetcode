using NUnit.Framework;

namespace LeetCode._010_Regular_Expression_Matching;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsMatch(testCase.S, testCase.P), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string P { get; private init; } = null!;
        public bool ExpectedResult { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aa",
                    P = "a",
                    ExpectedResult = false,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "aa",
                    P = "a*",
                    ExpectedResult = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "ab",
                    P = ".*",
                    ExpectedResult = true,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
