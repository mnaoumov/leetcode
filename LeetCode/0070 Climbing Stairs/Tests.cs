using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0070_Climbing_Stairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ClimbStairs(testCase.N), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 2,
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 3,
                    Output = 3,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}