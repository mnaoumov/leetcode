using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0345_Reverse_Vowels_of_a_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReverseVowels(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "hello",
                    // ReSharper disable once StringLiteralTypo
                    Output = "holle",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "leetcode",
                    // ReSharper disable once StringLiteralTypo
                    Output = "leotcede",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
