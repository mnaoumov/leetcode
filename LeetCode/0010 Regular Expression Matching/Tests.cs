using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0010_Regular_Expression_Matching;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsMatch(testCase.S, testCase.P), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string P { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aa",
                    P = "a",
                    Output = false,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "aa",
                    P = "a*",
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "ab",
                    P = ".*",
                    Output = true,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "ab",
                    P = ".*c",
                    Output = false,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S = "a",
                    P = "ab*a",
                    Output = false,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
