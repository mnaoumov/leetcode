using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0137_Single_Number_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SingleNumber(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 2, 3, 2 },
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 1, 0, 1, 0, 1, 99 },
                    Output = 99,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { -2, -2, 1, 1, 4, 1, 4, 4, -4, -2 },
                    Output = -4,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
