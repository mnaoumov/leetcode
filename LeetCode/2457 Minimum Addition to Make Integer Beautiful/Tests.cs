using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2457_Minimum_Addition_to_Make_Integer_Beautiful;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MakeIntegerBeautiful(testCase.N, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public long N { get; [UsedImplicitly] init; }
        public int Target { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 16,
                    Target = 6,
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 467,
                    Target = 6,
                    Output = 33,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    N = 1,
                    Target = 1,
                    Output = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
