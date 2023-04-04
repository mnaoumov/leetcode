
using JetBrains.Annotations;

namespace LeetCode._1337_The_K_Weakest_Rows_in_a_Matrix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.KWeakestRows(testCase.Mat, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Mat { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
