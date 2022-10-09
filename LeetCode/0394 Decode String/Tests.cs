using NUnit.Framework;

namespace LeetCode._0394_Decode_String;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DecodeString(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "3[a]2[bc]",
                    Return = "aaabcbc",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "3[a2[c]]",
                    Return = "accaccacc",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "2[abc]3[cd]ef",
                    Return = "abcabccdcdcdef",
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "abc3[cd]xyz",
                    Return = "abccdcdcdxyz",
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}