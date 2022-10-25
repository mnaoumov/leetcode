using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._1662_Check_If_Two_String_Arrays_are_Equivalent;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ArrayStringsAreEqual(testCase.Word1, testCase.Word2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Word1 { get; private init; } = null!;
        public string[] Word2 { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Word1 = new[] { "ab", "c" },
                    Word2 = new[] { "a", "bc" },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Word1 = new[] { "a", "cb" },
                    Word2 = new[] { "ab", "c" },
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Word1 = new[] { "abc", "d", "defg" },
                    // ReSharper disable once StringLiteralTypo
                    Word2 = new[] { "abcddefg" },
                    Output = true,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}