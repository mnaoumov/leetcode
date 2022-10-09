using NUnit.Framework;

namespace LeetCode._0043_Multiply_Strings;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Multiply(testCase.Num1, testCase.Num2), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Num1 { get; private init; } = null!;
        public string Num2 { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Num1 = "2",
                    Num2 = "3",
                    Return = "6",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Num1 = "123",
                    Num2 = "456",
                    Return = "56088",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Num1 = "0",
                    Num2 = "0",
                    Return = "0",
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Num1 = "999",
                    Num2 = "999",
                    Return = "998001",
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Num1 = "9133",
                    Num2 = "0",
                    Return = "0",
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}