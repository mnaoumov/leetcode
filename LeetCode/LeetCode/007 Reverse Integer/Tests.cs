using NUnit.Framework;

namespace LeetCode._007_Reverse_Integer;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Reverse(testCase.X), Is.EqualTo(testCase.Return));
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
                    X = 123,
                    Return = 321,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = -123,
                    Return = -321,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 120,
                    Return = 21,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
