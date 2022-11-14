using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0139_Word_Break;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.WordBreak(testCase.S, testCase.WordDict), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<string> WordDict { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "leetcode",
                    WordDict = new[] { "leet", "code" },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "applepenapple",
                    WordDict = new[] { "apple", "pen" },
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "catsandog",
                    WordDict = new[] { "cats", "dog", "sand", "and", "cat" },
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
