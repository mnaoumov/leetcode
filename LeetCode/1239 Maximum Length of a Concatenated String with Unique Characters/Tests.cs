using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1239_Maximum_Length_of_a_Concatenated_String_with_Unique_Characters;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxLength(testCase.Arr), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Arr { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Arr = new[] { "un", "iq", "ue" },
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Arr = new[] { "cha", "r", "act", "ers" },
                    Output = 6,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Arr = new[] { "abcdefghijklmnopqrstuvwxyz" },
                    Output = 26,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}