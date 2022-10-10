using NUnit.Framework;

namespace LeetCode._0063_Unique_Paths_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.UniquePathsWithObstacles(testCase.ObstacleGrid), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] ObstacleGrid { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ObstacleGrid = new[] { new[] { 0, 0, 0 }, new[] { 0, 1, 0 }, new[] { 0, 0, 0 } },
                    Output = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ObstacleGrid = new[] { new[] { 0, 1 }, new[] { 0, 0 } },
                    Output = 1,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}