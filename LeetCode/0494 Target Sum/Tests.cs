using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0494_Target_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindTargetSumWays(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int Output { get; private init; }


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 1, 1, 1 },
                    Target = 3,
                    Output = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    Target = 1,
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}