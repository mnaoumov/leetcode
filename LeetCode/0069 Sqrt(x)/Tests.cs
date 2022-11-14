using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0069_Sqrt_x_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MySqrt(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 4,
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = 8,
                    Output = 2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 1,
                    Output = 1,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    X = 2147395600,
                    Output = 46340,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    X = 0,
                    Output = 0,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}