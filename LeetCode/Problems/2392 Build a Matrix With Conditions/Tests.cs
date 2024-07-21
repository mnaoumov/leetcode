using JetBrains.Annotations;

namespace LeetCode.Problems._2392_Build_a_Matrix_With_Conditions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.BuildMatrix(testCase.K, testCase.RowConditions, testCase.ColConditions), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int K { get; [UsedImplicitly] init; }
        public int[][] RowConditions { get; [UsedImplicitly] init; } = null!;
        public int[][] ColConditions { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
