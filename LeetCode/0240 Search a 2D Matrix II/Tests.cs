using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0240_Search_a_2D_Matrix_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SearchMatrix(testCase.Matrix, testCase.Target), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 1, 4, 7, 11, 15 },
                        new[] { 2, 5, 8, 12, 19 },
                        new[] { 3, 6, 9, 16, 22 },
                        new[] { 10, 13, 14, 17, 24 },
                        new[] { 18, 21, 23, 26, 30 }
                    },
                    Target = 5,
                    Output = true,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 1, 4, 7, 11, 15 },
                        new[] { 2, 5, 8, 12, 19 },
                        new[] { 3, 6, 9, 16, 22 },
                        new[] { 10, 13, 14, 17, 24 },
                        new[] { 18, 21, 23, 26, 30 }
                    },
                    Target = 20,
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}