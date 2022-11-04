using JetBrains.Annotations;

namespace LeetCode._1706_Where_Will_the_Ball_Fall;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindBall(testCase.Grid), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Grid { get; private init; } = null!;
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { 1, 1, 1, -1, -1 }, new[] { 1, 1, 1, -1, -1 }, new[] { -1, -1, -1, 1, 1 },
                        new[] { 1, 1, 1, 1, -1 }, new[] { -1, -1, -1, -1, -1 }
                    },
                    Output = new[] { 1, -1, -1, -1, -1 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { -1 }
                    },
                    Output = new[] { -1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Grid = new[]
                    {
                        new[] { 1, 1, 1, 1, 1, 1 }, new[] { -1, -1, -1, -1, -1, -1 }, new[] { 1, 1, 1, 1, 1, 1 },
                        new[] { -1, -1, -1, -1, -1, -1 }
                    },
                    Output = new[] { 0, 1, 2, 3, 4, -1 },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
