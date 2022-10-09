using NUnit.Framework;

namespace LeetCode._0085_Maximal_Rectangle;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximalRectangle(testCase.Matrix), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Matrix { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '1', '0', '1', '0', '0' },
                        new[] { '1', '0', '1', '1', '1' },
                        new[] { '1', '1', '1', '1', '1' },
                        new[] { '1', '0', '0', '1', '0' }
                    },
                    Return = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '0' }
                    },
                    Return = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { '1' }
                    },
                    Return = 1,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}