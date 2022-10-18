using NUnit.Framework;

namespace LeetCode._0394_Decode_String;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DecodeString(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "3[a]2[bc]",
                    // ReSharper disable once StringLiteralTypo
                    Output = "aaabcbc",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "3[a2[c]]",
                    // ReSharper disable once StringLiteralTypo
                    Output = "accaccacc",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "2[abc]3[cd]ef",
                    // ReSharper disable once StringLiteralTypo
                    Output = "abcabccdcdcdef",
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "abc3[cd]xyz",
                    // ReSharper disable once StringLiteralTypo
                    Output = "abccdcdcdxyz",
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}