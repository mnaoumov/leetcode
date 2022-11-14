using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0218_The_Skyline_Problem;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetSkyline(testCase.Buildings), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Buildings { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Buildings = new[]
                    {
                        new[] { 2, 9, 10 },
                        new[] { 3, 7, 15 },
                        new[] { 5, 12, 12 },
                        new[] { 15, 20, 10 },
                        new[] { 19, 24, 8 }
                    },
                    Output = new[]
                    {
                        new[] { 2, 10 },
                        new[] { 3, 15 },
                        new[] { 7, 12 },
                        new[] { 12, 0 },
                        new[] { 15, 10 },
                        new[] { 20, 8 },
                        new[] { 24, 0 }
                    },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Buildings = new[]
                    {
                        new[] { 0, 2, 3 },
                        new[] { 2, 5, 3 }
                    },
                    Output = new[]
                    {
                        new[] { 0, 3 },
                        new[] { 5, 0 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}