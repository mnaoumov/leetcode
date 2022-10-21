using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0087_Scramble_String;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsScramble(testCase.S1, testCase.S2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S1 { get; private init; } = null!;
        public string S2 { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S1 = "great",
                    // ReSharper disable once StringLiteralTypo
                    S2 = "rgeat",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S1 = "abcde",
                    // ReSharper disable once StringLiteralTypo
                    S2 = "caebd",
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S1 = "a",
                    S2 = "a",
                    Output = true,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}