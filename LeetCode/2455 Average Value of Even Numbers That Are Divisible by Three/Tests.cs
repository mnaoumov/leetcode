using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2455_Average_Value_of_Even_Numbers_That_Are_Divisible_by_Three;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.AverageValue(testCase.Nums), Is.EqualTo(testCase.Output));
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
                    Nums = new[] { 1, 3, 6, 10, 12, 15 },
                    Output = 9,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 4, 7, 10 },
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
