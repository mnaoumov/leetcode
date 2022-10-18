using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1832_Check_if_the_Sentence_Is_Pangram;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckIfPangram(testCase.Sentence), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Sentence { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Sentence = "thequickbrownfoxjumpsoverthelazydog",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Sentence = "leetcode",
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}