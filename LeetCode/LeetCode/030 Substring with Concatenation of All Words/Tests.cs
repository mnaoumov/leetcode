using NUnit.Framework;

namespace LeetCode._030_Substring_with_Concatenation_of_All_Words;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindSubstring(testCase.S, testCase.Words), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string[] Words { get; private init; } = null!;
        public int[] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "barfoothefoobarman",
                    Words = new[] { "foo", "bar" },
                    Return = new[] { 0, 9 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "wordgoodgoodgoodbestword",
                    Words = new[] { "word", "good", "best", "word" },
                    Return = Array.Empty<int>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "barfoofoobarthefoobarman",
                    Words = new[] { "bar", "foo", "the" },
                    Return = new[] { 6, 9, 12 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}