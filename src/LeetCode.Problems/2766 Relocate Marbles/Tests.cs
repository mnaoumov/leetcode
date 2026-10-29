namespace LeetCode.Problems._2766_Relocate_Marbles;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RelocateMarbles(testCase.Nums, testCase.MoveFrom, testCase.MoveTo), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int[] MoveFrom { get; [UsedImplicitly] init; } = null!;
        public int[] MoveTo { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
