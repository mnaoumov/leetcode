using JetBrains.Annotations;

namespace LeetCode.Problems._2326_Spiral_Matrix_IV;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.SpiralMatrix(testCase.M, testCase.N, ListNode.Create(testCase.Head)), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
