
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0311_Sparse_Matrix_Multiplication;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.Multiply(testCase.Mat1, testCase.Mat2), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat1 { get; [UsedImplicitly] init; } = null!;
        public int[][] Mat2 { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
