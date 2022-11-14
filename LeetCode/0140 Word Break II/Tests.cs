using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0140_Word_Break_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.WordBreak(testCase.S, testCase.WordDict), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<string> WordDict { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "catsanddog",
                    WordDict = new[] { "cat", "cats", "and", "sand", "dog" },
                    Output = new[] { "cats and dog", "cat sand dog" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "pineapplepenapple",
                    // ReSharper disable once StringLiteralTypo
                    WordDict = new[] { "apple", "pen", "applepen", "pine", "pineapple" },
                    // ReSharper disable once StringLiteralTypo
                    Output = new[] { "pine apple pen apple", "pineapple pen apple", "pine applepen apple" },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "catsandog",
                    WordDict = new[] { "cats", "dog", "sand", "and", "cat" },
                    Output = Array.Empty<string>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
