using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0014_Longest_Common_Prefix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestCommonPrefix(testCase.Strs), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Strs { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Strs = new[] { "flower", "flow", "flight" },
                    Output = "fl",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Strs = new[] { "dog", "racecar", "car" },
                    Output = "",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
