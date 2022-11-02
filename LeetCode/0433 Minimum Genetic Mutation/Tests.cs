using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0433_Minimum_Genetic_Mutation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinMutation(testCase.Start, testCase.End, testCase.Bank), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Start { get; private init; } = null!;
        public string End { get; private init; } = null!;
        public string[] Bank { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Start = "AACCGGTT",
                    // ReSharper disable once StringLiteralTypo
                    End = "AACCGGTA",
                    // ReSharper disable once StringLiteralTypo
                    Bank = new[] { "AACCGGTA" },
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Start = "AACCGGTT",
                    // ReSharper disable once StringLiteralTypo
                    End = "AAACGGTA",
                    // ReSharper disable StringLiteralTypo
                    Bank = new[] { "AACCGGTA", "AACCGCTA", "AAACGGTA" },
                    // ReSharper restore StringLiteralTypo
                    Output = 2,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Start = "AAAAACCC",
                    // ReSharper disable once StringLiteralTypo
                    End = "AACCCCCC",
                    // ReSharper disable StringLiteralTypo
                    Bank = new[] { "AAAACCCC", "AAACCCCC", "AACCCCCC" },
                    // ReSharper restore StringLiteralTypo
                    Output = 3,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
