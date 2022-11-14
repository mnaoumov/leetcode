using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2451_Odd_String_Difference;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.OddString(testCase.Words), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Words = new[] { "adc", "wzy", "abc" },
                    Output = "abc",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Words = new[] { "aaa", "bob", "ccc", "ddd" },
                    Output = "bob",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
