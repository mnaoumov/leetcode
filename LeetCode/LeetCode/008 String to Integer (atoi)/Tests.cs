using NUnit.Framework;

namespace LeetCode._008_String_to_Integer__atoi_;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MyAtoi(testCase.S), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int ExpectedResult { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "42",
                    ExpectedResult = 42,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    S = "   -42",
                    ExpectedResult = -42,
                    TestCaseName = "Example 2"
                };
                
                yield return new TestCase
                {
                    S = "4193 with words",
                    ExpectedResult = 4193,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
