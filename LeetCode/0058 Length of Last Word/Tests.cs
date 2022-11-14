using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0058_Length_of_Last_Word;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LengthOfLastWord(testCase.S), Is.EqualTo(testCase.Output));
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
                    S = "Hello World",
                    Output = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "   fly me   to   the moon  ",
                    Output = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable StringLiteralTypo
                    S = "luffy is still joyboy",
                    // ReSharper restore StringLiteralTypo
                    Output = 6,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}