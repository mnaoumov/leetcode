
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1314_Matrix_Block_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MatrixBlockSum(testCase.Mat, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
