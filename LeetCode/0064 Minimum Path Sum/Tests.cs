using NUnit.Framework;

namespace LeetCode._0064_Minimum_Path_Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinPathSum(testCase.Grid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Grid { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Grid = new[] { new[] { 1, 3, 1 }, new[] { 1, 5, 1 }, new[] { 4, 2, 1 } },
                    Output = 7,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Grid = new[] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 } },
                    Output = 12,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}