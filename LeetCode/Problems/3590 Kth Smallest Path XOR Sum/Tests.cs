namespace LeetCode.Problems._3590_Kth_Smallest_Path_XOR_Sum;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.KthSmallest(testCase.Par, testCase.Vals, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Par { get; [UsedImplicitly] init; } = null!;
        public int[] Vals { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
