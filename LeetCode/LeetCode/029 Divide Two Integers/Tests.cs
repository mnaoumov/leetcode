using NUnit.Framework;

namespace LeetCode._029_Divide_Two_Integers;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Divide(testCase.Dividend, testCase.Divisor), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Dividend { get; private init; }
        public int Divisor { get; private init; }
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Dividend = 10,
                    Divisor = 3,
                    Return = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Dividend = 7,
                    Divisor = -3,
                    Return = -2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Dividend = 2147483647,
                    Divisor = 1,
                    Return = 2147483647
                };

                yield return new TestCase
                {
                    Dividend = -1010369383,
                    Divisor = -2147483648,
                    Return = 0
                };

                yield return new TestCase
                {
                    Dividend = 1100540749,
                    Divisor = -1090366779,
                    Return = -1
                };
            }
        }
    }
}