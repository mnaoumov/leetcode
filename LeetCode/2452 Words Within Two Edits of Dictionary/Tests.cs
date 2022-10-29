using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2452_Words_Within_Two_Edits_of_Dictionary;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TwoEditWords(testCase.Queries, testCase.Dictionary), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Queries { get; private init; } = null!;
        public string[] Dictionary { get; private init; } = null!;
        public IList<string> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Queries = new[] { "word", "note", "ants", "wood" },
                    Dictionary = new[] { "wood", "joke", "moat" },
                    Output = new[] { "word", "note", "wood" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Queries = new[] { "yes" },
                    Dictionary = new[] { "not" },
                    Output = Array.Empty<string>(),
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
