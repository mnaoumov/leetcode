using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0127_Word_Ladder;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LadderLength(testCase.BeginWord, testCase.EndWord, testCase.WordList), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string BeginWord { get; [UsedImplicitly] init; } = null!;
        public string EndWord { get; [UsedImplicitly] init; } = null!;
        public IList<string> WordList { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    BeginWord = "hit",
                    EndWord = "cog",
                    WordList = new[] { "hot", "dot", "dog", "lot", "log", "cog" },
                    Output = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    BeginWord = "hit",
                    EndWord = "cog",
                    WordList = new[] { "hot", "dot", "dog", "lot", "log" },
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
