using NUnit.Framework;

namespace LeetCode._014_Longest_Common_Prefix;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestCommonPrefix(testCase.Strs), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Strs { get; private init; } = null!;
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Strs = new[] { "flower", "flow", "flight" },
                    Return = "fl",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Strs = new[] { "dog", "racecar", "car" },
                    Return = "",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
