using JetBrains.Annotations;

namespace LeetCode._0068_Text_Justification;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FullJustify(testCase.Words, testCase.MaxWidth), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int MaxWidth { get; [UsedImplicitly] init; }
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Words = new[] { "This", "is", "an", "example", "of", "text", "justification." },
                    MaxWidth = 16,
                    Output = new[]
                    {
                        "This    is    an",
                        "example  of text",
                        "justification.  "
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Words = new[] { "What", "must", "be", "acknowledgment", "shall", "be" },
                    MaxWidth = 16,
                    Output = new[]
                    {
                        "What   must   be",
                        "acknowledgment  ",
                        "shall be        "
                    },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Words = new[]
                    {
                        "Science", "is", "what", "we", "understand", "well", "enough", "to", "explain", "to", "a",
                        "computer.", "Art", "is", "everything", "else", "we", "do"
                    },
                    MaxWidth = 20,
                    Output = new[]
                    {
                        "Science  is  what we",
                        "understand      well",
                        "enough to explain to",
                        "a  computer.  Art is",
                        "everything  else  we",
                        "do                  "
                    },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}