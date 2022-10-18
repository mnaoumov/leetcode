using NUnit.Framework;

namespace LeetCode._0030_Substring_with_Concatenation_of_All_Words;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindSubstring(testCase.S, testCase.Words), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string[] Words { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "barfoothefoobarman",
                    Words = new[] { "foo", "bar" },
                    Output = new[] { 0, 9 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "wordgoodgoodgoodbestword",
                    Words = new[] { "word", "good", "best", "word" },
                    Output = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "barfoofoobarthefoobarman",
                    Words = new[] { "bar", "foo", "the" },
                    Output = new[] { 6, 9, 12 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}