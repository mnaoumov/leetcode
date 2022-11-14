using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0766_Toeplitz_Matrix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsToeplitzMatrix(testCase.Matrix), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 1, 2, 3, 4 }, new[] { 5, 1, 2, 3 }, new[] { 9, 5, 1, 2 }
                    },
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[]
                    {
                        new[] { 1, 2 }, new[] { 2, 2 }
                    },
                    Output = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
