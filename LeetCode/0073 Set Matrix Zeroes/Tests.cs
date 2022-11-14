using JetBrains.Annotations;

namespace LeetCode._0073_Set_Matrix_Zeroes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var matrix = ArrayHelper.DeepCopy(testCase.Matrix);
        solution.SetZeroes(matrix);
        AssertCollectionEqualWithDetails(matrix, testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] Matrix { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Matrix = new[] { new[] { 1, 1, 1 }, new[] { 1, 0, 1 }, new[] { 1, 1, 1 } },
                    Output = new[] { new[] { 1, 0, 1 }, new[] { 0, 0, 0 }, new[] { 1, 0, 1 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Matrix = new[] { new[] { 0, 1, 2, 0 }, new[] { 3, 4, 5, 2 }, new[] { 1, 3, 1, 5 } },
                    Output = new[] { new[] { 0, 0, 0, 0 }, new[] { 0, 4, 5, 0 }, new[] { 0, 3, 1, 0 } },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}