using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._1544_Make_The_String_Great;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeGood(testCase.S), Is.EqualTo(testCase.Output));
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
                    S = "leEeetcode",
                    Output = "leetcode",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "abBAcC",
                    Output = "",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "s",
                    Output = "s",
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
