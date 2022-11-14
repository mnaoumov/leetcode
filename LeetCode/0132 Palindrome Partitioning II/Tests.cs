using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0132_Palindrome_Partitioning_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCut(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aab",
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "a",
                    Output = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "ab",
                    Output = 1,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "aaabaa",
                    Output = 1,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
