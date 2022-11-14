using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0008_String_to_Integer__atoi_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MyAtoi(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "42",
                    Output = 42,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    S = "   -42",
                    Output = -42,
                    TestCaseName = "Example 2"
                };
                
                yield return new TestCase
                {
                    S = "4193 with words",
                    Output = 4193,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "-91283472332",
                    Output = -2147483648,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
