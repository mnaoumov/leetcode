using NUnit.Framework;

namespace LeetCode._0069_Sqrt_x_;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MySqrt(testCase.X), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 4,
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = 8,
                    Return = 2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 1,
                    Return = 1,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    X = 2147395600,
                    Return = 46340,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    X = 0,
                    Return = 0,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}